using System;
using System.Runtime.Remoting;
public class InventoryWatcher : MarshalByRefObject{
    public static void Main () {
        RemotingConfiguration.Configure ("InventoryWatcher.exe.config", false);
        InventoryManager inventoryManager = new InventoryManager ();
        InventoryWatcher inventoryWatcher = new InventoryWatcher();
        inventoryManager.InventoryChangeEvent += inventoryWatcher.watcher;
        Console.WriteLine ("[InventoryWatcher]");
        Console.WriteLine ("Press Enter to terminate.");
        Console.ReadLine ();
        inventoryManager.InventoryChangeEvent -= inventoryWatcher.watcher;
    }

    private void watcher(Object sender, InventoryChangeArgs info){
        info.watch();
    }
}