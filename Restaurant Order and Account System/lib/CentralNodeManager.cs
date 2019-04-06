using System;
using System.Runtime.Remoting;
using System.Collections.Generic;

public class CentralNodeManager : MarshalByRefObject{
    private Dictionary <int, Order> orders;
    public delegate void OrderHandler(List<OrderPart> order);
    public event OrderHandler OrderEvent;

    private void handler(List<OrderPart> order){}

    public CentralNodeManager(){
        this.orders = new Dictionary<int, Order>();
        this.OrderEvent += this.handler;
    }

    public void handleOrder(Order order){
        Console.WriteLine("CentralNode received order: \n" + order.ToString());
        if(!this.orders.ContainsKey(order.Id))
            this.orders.Add(order.Id, order);
            
        this.OrderEvent(order.OrderParts);
    }
}