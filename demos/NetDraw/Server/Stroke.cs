using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

[Serializable]
public class Stroke
{
  ArrayList Points = new ArrayList();

  public int Count
  {
    get { return Points.Count; }
  }

  public Stroke(int x, int y)
  {
    Points.Add(new Point(x, y));
  }

  public void Add(int x, int y)
  {
    Points.Add(new Point(x, y));
  }

  public Point GetPoint(int pos)
  {
    return (Point) Points[pos];
  }

  public void Draw(Graphics g)
  {
    Pen pen = new Pen(Color.Black, 8);
    pen.EndCap = LineCap.Round;
    for (int i=0; i<Points.Count - 1; i++)
      g.DrawLine(pen, (Point) Points[i], (Point) Points[i + 1]);
    pen.Dispose();
  }
}