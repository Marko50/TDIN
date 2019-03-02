using System;

public class RemObj: MarshalByRefObject
{
  private B b;
  private A a;

  public RemObj() {
    Console.WriteLine("[RemObj]: Constructor called");
  }

  public A GetA() {
    Console.WriteLine("[RemObj]: GetA() called: A initialized with 11");
    return new A(11);
  }

  public B GetB() {
    Console.WriteLine("[RemObj]: GetB() called: B initialized with 22");
    return new B(22);
  }

  public void SetA(A a) {
    Console.WriteLine("[RemObj]: SetA() called: Got an A");
    this.a = a;
  }

  public int UseA() {
    Console.WriteLine("[RemObj]: UseA() called: return Data");
    return a.Data;
  }

  public void SetB(B b) {
    Console.WriteLine("[RemObj]: SetB() called: Got a B");
    this.b = b;
  }

  public int UseB() {
    Console.WriteLine("[RemObj]: UseB() called: return Data");
    return b.Data;
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
