using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

public delegate void SegmentHandler(int x1, int y1, int x2, int y2);
public delegate void EndHandler(Stroke stroke);
public delegate void ClearHandler();

public interface IPaper {
  event SegmentHandler NewSegment;
  event EndHandler LastSegment;
  event ClearHandler ClearAll;

  ArrayList GetStrokes();
  Stroke GetCurrent();
  void BeginStroke(int x, int y);
  void DrawSegment(int x, int y);
  void EndStroke(int x, int y);
  void Clear();
}

public class Intermediate : MarshalByRefObject {
  public event SegmentHandler NewSegment;
  public event EndHandler LastSegment;
  public event ClearHandler ClearAll;

  public void FireNewSegment(int x1, int y1, int x2, int y2) {
    NewSegment(x1, y1, x2, y2);
  }

  public void FireLastSegment(Stroke stroke) {
    LastSegment(stroke);
  }

  public void FireClearAll() {
    ClearAll();
  }

  public override object InitializeLifetimeService() {
    return null;
  }
}

[Serializable]
public class Stroke {
  ArrayList Points = new ArrayList();

  public int Count {
    get { return Points.Count; }
  }

  public Stroke(int x, int y) {
    Points.Add(new Point(x, y));
  }

  public void Add(int x, int y) {
    Points.Add(new Point(x, y));
  }

  public Point GetPoint(int pos) {
    return (Point)Points[pos];
  }

  public void Draw(Graphics g) {
    Pen pen = new Pen(Color.Black, 8);
    pen.EndCap = LineCap.Round;
    for (int i = 0; i < Points.Count - 1; i++)
      g.DrawLine(pen, (Point)Points[i], (Point)Points[i + 1]);
    pen.Dispose();
  }
}