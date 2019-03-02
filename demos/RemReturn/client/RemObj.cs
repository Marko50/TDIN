using System;

public class RemObj: MarshalByRefObject {
  public A GetA() {
    return null;
  }

  public B GetB() {
    return null;
  }

  public void SetA(A a) {
  }

  public int UseA() {
    return 0;
  }

  public void SetB(B b) {
  }

  public int UseB() {
    return 0;
  }
}

[Serializable]
public class A {
  private int data;

  public A(int data) {
    Console.WriteLine("[Client A]: constructor called");
    this.data = data;
  }

  public int Data {
    get {
      Console.WriteLine("[Client A]: Property Data read");
      return data;
    }
  }
}

public class B : MarshalByRefObject {
  public B(int data) {
  }
 
  public int Data {
    get {
      return 0;
    }
  }
}
