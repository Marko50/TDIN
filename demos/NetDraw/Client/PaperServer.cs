using System;
using System.Collections;

public delegate void SegmentHandler(int x1, int y1, int x2, int y2);
public delegate void EndHandler(Stroke stroke);
public delegate void ClearHandler();

public class Paper : MarshalByRefObject
{
  public event SegmentHandler NewSegment;
  public event EndHandler LastSegment;
  public event ClearHandler ClearAll;

  public ArrayList GetStrokes()
  {
    return null;
  }

  public Stroke GetCurrent()
  {
    return null;
  }
  
  public void BeginStroke(int x, int y)
  {
  }
  
  public void DrawSegment(int x, int y)
  {
  }

  public void EndStroke(int x, int y)
  {
  }

  public void Clear()
  {
  }
}