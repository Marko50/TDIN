using System;
using System.Runtime.Remoting;

public class CentralNode : MarshalByRefObject{
    public delegate void OrderHandler(Order order);
    public event OrderHandler OrderEvent;

    private void handler(Order order){}

    public CentralNode(){
        this.OrderEvent += this.handler;
    }

    public void handleOrder(Order order){
        Console.WriteLine("CentralNode received order: \n" + order.ToString());
        this.OrderEvent(order);
    }
}