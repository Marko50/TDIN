using System;
using System.Runtime.Remoting;
using System.Collections.Generic;
public class CentralNodeManager : MarshalByRefObject{
    private Dictionary <int, Order> orders;
    public delegate void OrderHandler(Order order);
    public event OrderHandler OrderEvent;

    private void handler(Order order){}

    public CentralNodeManager(){
        this.orders = new Dictionary<int, Order>();
        this.OrderEvent += this.handler;
    }

    public void handleOrder(Order order){
        Console.WriteLine("CentralNode received order: \n" + order.ToString());
        if(!this.orders.ContainsKey(order.Id))
            this.orders.Add(order.Id, order);
            
        this.OrderEvent(order);
    }
}