using System;
using System.Runtime.Remoting;
using Manager;
using Shared;

namespace InventoryLog {
  class Program {
    static void Main(string[] args) {
      RemotingConfiguration.Configure("InventoryLog.exe.config", false);
      InventoryManager manager = new InventoryManager();
      Logger log = new Logger();
      manager.inventoryChangeEvent += log.LogChanges;
      Console.WriteLine("[InventoryLog]");
      Console.WriteLine("Press Enter to terminate.");
      Console.ReadLine();
      manager.inventoryChangeEvent -= log.LogChanges;
    }
  }

  class Logger : MarshalByRefObject {
    public void LogChanges(InventoryChangeArgs parameter) {
      int change = parameter.Change;
      Console.WriteLine("[InventoryLog]: Part \"{0}\" was {1} by {2} units.", parameter.Pno,
                        change > 0 ? "increased" : "decreased", Math.Abs(change));

    }
  }
}
