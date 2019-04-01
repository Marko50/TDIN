using System;
using System.Runtime.Remoting;

public class DiningRoon {
    public static void Main(){
        RemotingConfiguration.Configure("Clients/DiningRoom/DiningRoom.exe.config",false);
        Console.WriteLine("About to call remote handle order.  Press Enter.");
        Console.ReadLine();
        CentralNode centalNode = new CentralNode();
        centalNode.handleOrder(new Order());
    }
}