using System;
using System.Runtime.Remoting;

class Client {
  static void Main() {
    RemotingConfiguration.Configure("Client.exe.config");
    RemObj obj = new RemObj();

    A a = obj.GetA();
    int a1 = a.Data;
    Console.WriteLine("[Client]: a.Data = {0}", a1);
    B b = obj.GetB();
    int b1 = b.Data;
    Console.WriteLine("[Client]: b.Data = {0}", b1);
    Console.ReadLine();
  }
}
