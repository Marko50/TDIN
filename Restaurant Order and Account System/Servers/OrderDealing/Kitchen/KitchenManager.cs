using System;
using System.Runtime.Remoting;
using System.Collections.Generic;

public class KitchenManager : OrderDealing{
    public KitchenManager() : base(){
        this.type = "Kitchen";
    }
    public static void Main(){
        RemotingConfiguration.Configure("Servers/OrderDealing/Kitchen/KitchenManager.exe.config", false);
        KitchenManager kitchen = new KitchenManager();
        CentralNodeManager centralNode = new CentralNodeManager();
        centralNode.OrderEvent += kitchen.handleOrder;
        centralNode.OrderChangeEvent += kitchen.changeOrderStatus;
        Console.WriteLine("Kitchen was opened! Press ENTER to exit!");
        Console.ReadLine();
        centralNode.OrderEvent -= kitchen.handleOrder;
        centralNode.OrderChangeEvent -= kitchen.changeOrderStatus;
    }
}