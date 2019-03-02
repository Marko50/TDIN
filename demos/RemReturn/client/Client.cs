using System;
using System.Runtime.Remoting;

class Client {
  static void Main() {
    RemotingConfiguration.Configure("Client.exe.config");
    RemObj obj = new RemObj();

    Console.WriteLine("[Client]: call GetA()");
    A a = obj.GetA();
    int a1 = a.Data;
    Console.WriteLine("[Client]: a.Data = {0}", a1);
    Console.ReadLine();
    Console.WriteLine("[Client]: call GetB()");
    B b = obj.GetB();
    int b1 = b.Data;
    Console.WriteLine("[Client]: b.Data = {0}", b1);
    Console.ReadLine();
    Console.WriteLine("[Client]: construct an A initialized with 33");
    a = new A(33);
    a1 = a.Data;
    Console.WriteLine("[Client]: a.Data = {0}", a1);
    Console.ReadLine();
    Console.WriteLine("[Client]: call SetA()");
    obj.SetA(a);
    Console.WriteLine("[Client]: call UseA()");
    a1 = obj.UseA();
    Console.WriteLine("[Client]: returned from UseA = {0}", a1);
    Console.ReadLine();
    Console.WriteLine("[Client]: construct a B initialized with 44");
    b = new B(44);
    b1 = b.Data;
    Console.WriteLine("[Client]: b.Data = {0}", b1);
    Console.ReadLine();
    Console.WriteLine("[Client]: call SetB()");
    obj.SetB(b);
    Console.WriteLine("[Client]: call UseB()");
    b1 = obj.UseB();
    Console.WriteLine("[Client]: returned from UseB = {0}", b1);
    Console.ReadLine();
  }
}
