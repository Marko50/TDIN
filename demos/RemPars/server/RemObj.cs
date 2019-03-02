using System;

public class RemObj: MarshalByRefObject {
  public RemObj() {
    Console.WriteLine("[RemObj]: Constructor called");
  }

  public A GetA() {
    Console.WriteLine("[RemObj]: GetA() called");
    return new A(11);
  }

  public B GetB() {
    Console.WriteLine("[RemObj]: GetB() called");
    return new B(22);
  }
}

[Serializable]
public class A {
  private int data;

  public A(int data) {
    Console.WriteLine("[A]: constructor called");
    this.data = data;
  }

  public int Data {
    get {
      Console.WriteLine("[A]: Property Data read");
      return data;
    }
  }
}

public class B : MarshalByRefObject {
  private int data;

  public B(int data) {
    Console.WriteLine("[B]: constructor called");
    this.data = data;
  }

  public int Data {
    get {
      Console.WriteLine("[B]: Property Data read");
      return data;
    }
  }
}
