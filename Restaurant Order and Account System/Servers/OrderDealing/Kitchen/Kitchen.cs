using System;
using System.Runtime.Remoting;
using System.Collections.Generic;

public class Kitchen : OrderDealing{
    public Kitchen() : base(){
        this.type = "Kitchen";
    }
    public static void Main(){
        RemotingConfiguration.Configure("Servers/OrderDealing/Kitchen/Kitchen.exe.config", false);
        Kitchen kitchen = new Kitchen();
        CentralNodeManager centralNode = new CentralNodeManager();
        centralNode.OrderEvent += kitchen.handleOrder; 
        Console.WriteLine("Kitchen was opened! Press ENTER to exit!");
        Console.ReadLine();
        centralNode.OrderEvent -= kitchen.handleOrder;
    }
}