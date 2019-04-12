using System;
using System.Runtime.Remoting;
using System.Collections.Generic;

public class BarManager : OrderDealing{
    protected Dictionary <int, OrderPart> orders;

    public BarManager() : base(){
        this.type = "Bar";
    }
    public static void Main(){
        RemotingConfiguration.Configure("Servers/OrderDealing/Bar/BarManager.exe.config", false);
        BarManager bar = new BarManager();
        CentralNodeManager centralNode = new CentralNodeManager();
        centralNode.OrderEvent += bar.handleOrder; 
        centralNode.OrderChangeEvent += bar.changeOrderStatus;
        Console.WriteLine("Bar was opened! Press ENTER to exit!");
        Console.ReadLine();
        centralNode.OrderEvent -= bar.handleOrder;
        centralNode.OrderChangeEvent -= bar.changeOrderStatus;
    }
}