using System;

public class RemObj: MarshalByRefObject {
  public A GetA() {
    return null;
  }

  public B GetB() {
    return null;
  }
}

[Serializable]
public class A {
  private int data;

  public int Data {
    get {
      Console.WriteLine("[Client A]: Property Data read");
      return data;
    }
  }
}

public class B : MarshalByRefObject {

  public int Data {
    get {
      return 0;
    }
  }
}
