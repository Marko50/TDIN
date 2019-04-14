using System;
using System.Runtime.Remoting;

public class DiningRoom : MarshalByRefObject {
    public static void Main(){
        RemotingConfiguration.Configure("Clients/DiningRoom/DiningRoom.exe.config",false);
        Console.WriteLine("About to call remote handle order.  Press Enter.");
        Console.ReadLine();
        CentralNodeManager centralNode = new CentralNodeManager();
        DiningRoom diningRoom = new DiningRoom();
        centralNode.OrderReadyEvent += diningRoom.handleReadyOrder;
        centralNode.handleOrder(new Order());
        Console.WriteLine("Close the dining room.  Press Enter.");
        Console.ReadLine();
    }

    private void handleReadyOrder(int orderID){
        Console.WriteLine("\r\n\r\nOrder no " + orderID + " is ready to be picked.\r\n\r\n");
    }
}