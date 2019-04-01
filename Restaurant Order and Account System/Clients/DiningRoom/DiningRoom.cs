using System;
using System.Runtime.Remoting;

public class DiningRoom {
    public static void Main(){
        RemotingConfiguration.Configure("Clients/DiningRoom/DiningRoom.exe.config",false);
        Console.WriteLine("About to call remote handle order.  Press Enter.");
        Console.ReadLine();
        CentralNodeManager centralNode = new CentralNodeManager();
        centralNode.handleOrder(new Order());
    }
}