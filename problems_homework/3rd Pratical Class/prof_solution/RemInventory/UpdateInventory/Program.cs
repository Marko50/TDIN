using System;
using System.Runtime.Remoting;
using System.Threading;
using Manager;

namespace UpdateInventory {
  class Program {
    static void Main(string[] args) {
      RemotingConfiguration.Configure("UpdateInventory.exe.config", false);
      InventoryManager man = new InventoryManager();
      Console.WriteLine("[UpdateInventory]");
      Console.WriteLine("About to call remote UpdateInventory().  Press Enter.");
      Console.ReadLine();
      while (true) {
        man.UpdateInventory("wood table", 100);
        Console.WriteLine("[UpdateInventory]: Called UpdateInventory() with {\"wood table\", 100}");
        Thread.Sleep(1000);
      }
    }
  }
}
