using System;
using System.Runtime.Remoting;
public class InventoryLoger : MarshalByRefObject{
    public static void Main(){
        RemotingConfiguration.Configure ("InventoryLoger.exe.config", false);
        InventoryManager inventoryManager = new InventoryManager ();
        InventoryLoger inventoryLoger = new InventoryLoger();
        inventoryManager.InventoryChangeEvent += inventoryLoger.log;
        Console.WriteLine ("[InventoryLoger]");
        Console.WriteLine ("Press Enter to terminate.");
        Console.ReadLine ();
        inventoryManager.InventoryChangeEvent -= inventoryLoger.log;
    }
    private void log(Object sender, InventoryChangeArgs info){
        info.log();
    }   
}