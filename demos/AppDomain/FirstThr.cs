using System;
using System.Threading;

class App {
  static void Main(string[] args) {
    Console.WriteLine("I'm running on the domain: {0}", AppDomain.CurrentDomain.FriendlyName);
    Thread t = new Thread(() => {
      AppDomain second = AppDomain.CreateDomain("Second.exe");
      second.ExecuteAssembly("Second.exe");
    });
    t.Start();
    Thread.Sleep(100);
    Console.WriteLine("First domain ending ...");
  }
}