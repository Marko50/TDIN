using System;

class App {
  static void Main(string[] args) {
    Console.WriteLine("I'm running on the domain: {0}", AppDomain.CurrentDomain.FriendlyName);
    Console.ReadKey(true);
    Console.WriteLine("Second domain ending ...");
  }
}