using System;
using System.Runtime.Remoting.Messaging;
using System.Collections;

public delegate void SegmentHandler(int x1, int y1, int x2, int y2);
public delegate void EndHandler(Stroke stroke);
public delegate void ClearHandler();

public class Paper : MarshalByRefObject
{
  Stroke current = null;
  ArrayList strokes = new ArrayList();

  public event SegmentHandler NewSegment;
  public event EndHandler LastSegment;
  public event ClearHandler ClearAll;

  public override object InitializeLifetimeService()
  {
    Console.WriteLine("InitilizeLifetimeService");
    return null;
  }

  public ArrayList GetStrokes()
  {
    return strokes;
  }

  public Stroke GetCurrent()
  {
    return current;
  }
  
  public void BeginStroke(int x, int y)
  {
    current = new Stroke(x, y);
  }
  
  public void DrawSegment(int x, int y)
  {
    current.Add(x, y);
    if (NewSegment != null) {
      int cnt = current.Count;
      NewSegment(current.GetPoint(cnt-2).X, current.GetPoint(cnt-2).Y, x, y);
    }
  }

  public void EndStroke(int x, int y)
  {
    current.Add(x, y);
    strokes.Add(current);
    if (NewSegment != null) {
      int cnt = current.Count;
      NewSegment(current.GetPoint(cnt-2).X, current.GetPoint(cnt-2).Y, x, y);
    }
    if (LastSegment != null)
      LastSegment(current);
    current = null;
  }

  public void Clear()
  {
    strokes.Clear();
    if (ClearAll != null)
      ClearAll();
  }
}