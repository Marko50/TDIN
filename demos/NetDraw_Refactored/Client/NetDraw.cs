using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting;
using System.ComponentModel;

class MyForm : Form {
  IPaper virtualPaper;
  Intermediate inter;
  ArrayList strokes = new ArrayList();

  MyForm() {
    Text = "NetDraw";
    try {
      RemotingConfiguration.Configure("NetDraw.exe.config", false);
      inter = new Intermediate();
      inter.NewSegment += OnNewSegment;
      inter.LastSegment += OnLastSegment;
      inter.ClearAll += OnClear;
      virtualPaper = (IPaper) GetRemote.New(typeof(IPaper));
      virtualPaper.NewSegment += inter.FireNewSegment;
      virtualPaper.LastSegment += inter.FireLastSegment;
      virtualPaper.ClearAll += inter.FireClearAll;
    }
    catch (Exception ex) {
      MessageBox.Show (ex.Message);
      Close();
    }
    strokes = virtualPaper.GetStrokes();
  }

  public override object InitializeLifetimeService() {
    return null;
  }

  protected override void OnPaint(PaintEventArgs e) {
    lock (strokes.SyncRoot) {
      foreach (Stroke stroke in strokes)
        stroke.Draw(e.Graphics);
    }
  }

  protected override void OnMouseDown(MouseEventArgs e) {
    if (e.Button == MouseButtons.Left)
      virtualPaper.BeginStroke(e.X, e.Y);
  }

  protected override void OnMouseMove(MouseEventArgs e) {
    if ((e.Button & MouseButtons.Left) != 0)
      virtualPaper.DrawSegment(e.X, e.Y);
  }

  protected override void OnMouseUp(MouseEventArgs e) {
    if (e.Button == MouseButtons.Left)
      virtualPaper.EndStroke(e.X, e.Y);
  }

  protected override void OnKeyDown(KeyEventArgs e) {
    if (e.KeyCode == Keys.Delete)
      virtualPaper.Clear();
  }

  protected override void OnClosing(CancelEventArgs e) {
    base.OnClosing(e);
    virtualPaper.NewSegment -= inter.FireNewSegment;
    virtualPaper.LastSegment -= inter.FireLastSegment;
    virtualPaper.ClearAll -= inter.FireClearAll;
  }

  public void OnNewSegment(int x1, int y1, int x2, int y2) {
    Graphics g = Graphics.FromHwnd(Handle);
    Pen pen = new Pen(Color.Black, 8);
    pen.EndCap = LineCap.Round;
    g.DrawLine(pen, x1, y1, x2, y2);
    pen.Dispose();
    g.Dispose();
  }

  public void OnLastSegment(Stroke stroke) {
    strokes.Add(stroke);
  }

  public void OnClear() {
    strokes.Clear();
    Invalidate();
  }

  static void Main () {
    Application.Run(new MyForm());
  }
}

class GetRemote {
  private static IDictionary wellKnownTypes;

  public static object New(Type type) {
    if (wellKnownTypes == null)
      InitTypeCache();
    WellKnownClientTypeEntry entry = (WellKnownClientTypeEntry)wellKnownTypes[type];
    if (entry == null)
      throw new RemotingException("Type not found!");
    return Activator.GetObject(type, entry.ObjectUrl);
  }

  public static void InitTypeCache() {
    Hashtable types = new Hashtable();
    foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes()) {
      if (entry.ObjectType == null)
        throw new RemotingException("A configured type could not be found!");
      types.Add(entry.ObjectType, entry);
    }
    wellKnownTypes = types;
  }
}