using System;
using System.Runtime.Remoting;
public class Client{
    public static void Main(){
        RemotingConfiguration.Configure("Client.exe.config", false);
        InventoryManager inventoryManager = new InventoryManager();
        Console.WriteLine("[UpdateInventory]");
        Console.WriteLine("About to call remote UpdateInventory().  Press Enter.");
        Console.ReadLine();
        inventoryManager.UpdateInventory("Part_1", 3);
    }
}