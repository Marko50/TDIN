using System;
using System.Runtime.Remoting;

class Client {
  static void Main(string[] args) {
    int v = 7;

    RemotingConfiguration.Configure("Client.exe.config", false);
    Remote obj = new Remote();
    Console.WriteLine(obj.Hello());
    Console.ReadLine();
    Console.WriteLine(obj.Modify(ref v));
    Console.WriteLine("Client after: {0}", v);
  }
}
