using System;
using System.Runtime.Remoting;
using System.Collections.Generic;

public class Bar : MarshalByRefObject{
    private Dictionary <int, Order> orders;

    public Bar(){
        this.orders = new Dictionary<int, Order>();
    }
    public static void Main(){
        RemotingConfiguration.Configure("Servers/Bar/Bar.exe.config", false);
        Bar bar = new Bar();
        CentralNodeManager centralNode = new CentralNodeManager();
        centralNode.OrderEvent += bar.handleOrder; 
        Console.WriteLine("Bar was opened! Press ENTER to exit!");
        Console.ReadLine();
        centralNode.OrderEvent -= bar.handleOrder;
    }

    private void handleOrder(Order order){
        Console.WriteLine("Bar received order: \n" + order.ToString()); 
        if(!this.orders.ContainsKey(order.Id))
            this.orders.Add(order.Id, order);
    }
}