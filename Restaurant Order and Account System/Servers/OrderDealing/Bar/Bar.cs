using System;
using System.Runtime.Remoting;
using System.Collections.Generic;

public class Bar : OrderDealing{
    protected Dictionary <int, OrderPart> orders;

    public Bar() : base(){
        this.type = "Bar";
    }
    public static void Main(){
        RemotingConfiguration.Configure("Servers/OrderDealing/Bar/Bar.exe.config", false);
        Bar bar = new Bar();
        CentralNodeManager centralNode = new CentralNodeManager();
        centralNode.OrderEvent += bar.handleOrder; 
        Console.WriteLine("Bar was opened! Press ENTER to exit!");
        Console.ReadLine();
        centralNode.OrderEvent -= bar.handleOrder;
    }
}