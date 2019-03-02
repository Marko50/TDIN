using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting;
using System.ComponentModel;

class MyForm : Form
{
  Paper VirtualPaper;
  ArrayList strokes = new ArrayList();
  SegmentHandler SH;
  EndHandler EH;
  ClearHandler CH;

  MyForm()
  {
    Text = "NetDraw";
    try {
      RemotingConfiguration.Configure("NetDraw.exe.config");
      VirtualPaper = new Paper();
      VirtualPaper.NewSegment += (SH = new SegmentHandler(OnNewSegment));
      VirtualPaper.LastSegment += (EH = new EndHandler(OnLastSegment));
      VirtualPaper.ClearAll += (CH = new ClearHandler(OnClear));
    }
    catch (Exception ex) {
      MessageBox.Show (ex.Message);
      Close();
    }
    strokes = VirtualPaper.GetStrokes();
  }

  public override object InitializeLifetimeService()
  {
    return null;
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    lock (strokes.SyncRoot) {
      foreach (Stroke stroke in strokes)
        stroke.Draw(e.Graphics);
    }
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    if (e.Button == MouseButtons.Left)
      VirtualPaper.BeginStroke(e.X, e.Y);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    if ((e.Button & MouseButtons.Left) != 0)
      VirtualPaper.DrawSegment(e.X, e.Y);
  }

  protected override void OnMouseUp(MouseEventArgs e)
  {
    if (e.Button == MouseButtons.Left)
      VirtualPaper.EndStroke(e.X, e.Y);
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    if (e.KeyCode == Keys.Delete)
      VirtualPaper.Clear();
  }

  protected override void OnClosing(CancelEventArgs e)
  {
    base.OnClosing(e);
    VirtualPaper.NewSegment -= SH;
    VirtualPaper.LastSegment -= EH;
    VirtualPaper.ClearAll -= CH;
  }

  public void OnNewSegment(int x1, int y1, int x2, int y2)
  {
    Graphics g = Graphics.FromHwnd(Handle);
    Pen pen = new Pen(Color.Black, 8);
    pen.EndCap = LineCap.Round;
    g.DrawLine(pen, x1, y1, x2, y2);
    pen.Dispose();
    g.Dispose();
  }

  public void OnLastSegment(Stroke stroke)
  {
    strokes.Add(stroke);
  }

  public void OnClear()
  {
    strokes.Clear();
    Invalidate();
  }

  static void Main ()
  {
    Application.Run(new MyForm());
  }
}