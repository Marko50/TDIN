using System;
using System.Runtime.Remoting;
using System.Threading;
public class Client{
    public static void Main(){
        RemotingConfiguration.Configure("Client.exe.config", false);
        InventoryManager inventoryManager = new InventoryManager();
        Console.WriteLine("[UpdateInventory]");
        Console.WriteLine("About to call remote UpdateInventory().  Press Enter.");
        Console.ReadLine();
        int counter = 0;
        while (counter < 10) {
        inventoryManager.UpdateInventory("wood table_" + (counter + 1), counter*100);
        Thread.Sleep(1000);
        counter+=1;
      }
    }
}