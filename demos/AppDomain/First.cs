using System;

class App {
  static void Main(string[] args) {
    Console.WriteLine("I'm running on the domain: {0}", AppDomain.CurrentDomain.FriendlyName);
    AppDomain second = AppDomain.CreateDomain("Second.exe");
    second.ExecuteAssembly("Second.exe");
    Console.WriteLine("First domain ending ...");
  }
} 