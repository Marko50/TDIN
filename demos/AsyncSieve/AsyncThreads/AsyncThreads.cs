using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncThreads {
  class Program {
    static Stopwatch watch = new Stopwatch();

    static void Main(string[] args) {
      int t = 1;

      watch.Start();
      Console.WriteLine("Main start: {0}", Thread.CurrentThread.ManagedThreadId);
      Console.WriteLine("Main start: {0} ms", watch.ElapsedMilliseconds);
      Program p = new Program();
      Task<int> r = p.AsyncMethod(40);
      Console.WriteLine("Main after: {0}", Thread.CurrentThread.ManagedThreadId);
      Console.WriteLine("Main after: {0} ms", watch.ElapsedMilliseconds);
      while (!Console.KeyAvailable) {
        Thread.Sleep(1000);
        Console.Write("..{0}", t++);
      }
      Console.ReadKey(true);
      Console.WriteLine("\nValue = {0}", r.Result);
    }

    async Task<int> AsyncMethod(int par) {
      Console.WriteLine("AsyncMethod preparation: {0}", Thread.CurrentThread.ManagedThreadId);
      Console.WriteLine("AsyncMethod start: {0} ms", watch.ElapsedMilliseconds);
      await Task.Run(() => {
        Console.WriteLine("Task start: {0}", Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("Task start: {0} ms", watch.ElapsedMilliseconds);
        Thread.Sleep(5000);
        Console.WriteLine("\nTask end: {0}", Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("Task end: {0} ms", watch.ElapsedMilliseconds);
        par++;
      });
      Console.WriteLine("AsyncMethod completion: {0}", Thread.CurrentThread.ManagedThreadId);
      Console.WriteLine("AsyncMethod end: {0} ms", watch.ElapsedMilliseconds);
      return par;
    }
  }
}
