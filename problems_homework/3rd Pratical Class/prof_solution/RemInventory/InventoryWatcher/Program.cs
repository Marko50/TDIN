using System;
using System.Runtime.Remoting;
using Manager;
using Shared;

namespace InventoryWatcher {
  class Program : MarshalByRefObject {
    static void Main(string[] args) {
      RemotingConfiguration.Configure("InventoryWatcher.exe.config", false);
      InventoryManager man = new InventoryManager();
      Program prog = new Program();
      man.inventoryChangeEvent += prog.Handler;
      Console.WriteLine("[InventoryWatcher]");
      Console.WriteLine("Press Enter to terminate.");
      Console.ReadLine();
      man.inventoryChangeEvent -= prog.Handler;
    }

    public void Handler(InventoryChangeArgs parm) {
      Console.WriteLine("[InventoryWatcher]: Inventory of part \"{0}\" has changed.", parm.Pno);
    }
  }
}
