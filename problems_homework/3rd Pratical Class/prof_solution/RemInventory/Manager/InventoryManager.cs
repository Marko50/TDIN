using System;
using Shared;

namespace Manager {
  public class InventoryManager : MarshalByRefObject {
    public event InventoryChangeHandler inventoryChangeEvent;

    public InventoryManager() {
      Console.WriteLine("[InventoryManager]: Constructor called ...");
    }

    public void UpdateInventory(string pno, int change) {
      Console.WriteLine("[InventoryManager]: UpdateInventory() called with (\"{0}\", {1})", pno, change);
      if (change == 0)
        return;
      InventoryChangeArgs parameter = new InventoryChangeArgs(pno, change);
      if (inventoryChangeEvent != null) {
        Console.WriteLine("[InventoryManager]: Raising event ...");
        inventoryChangeEvent(parameter);
      }

    }
  }
}