using System;
using System.Runtime.Remoting;
using System.Collections.Generic;

public class CentralNodeManager : MarshalByRefObject{
    private Dictionary <int, Order> orders;
    public delegate void OrderHandler(List<OrderPart> order);
    public event OrderHandler OrderEvent;

    public delegate void OrderReadyHandler(Order order);
    public event OrderReadyHandler OrderReadyEvent;

    public delegate void OrderServedHandler(Order order);
    public event OrderServedHandler OrderServedEvent;

    private void handler(List<OrderPart> order){}

    private void changeHandler(int orderPartID, string status){}

    private void readyHandler(Order order){}

    private void servedHandler(Order order){}

    public CentralNodeManager(){
        this.orders = new Dictionary<int, Order>();
        this.OrderEvent += this.handler;
        this.OrderReadyEvent += this.readyHandler;
        this.OrderServedEvent += this.servedHandler;
    }

    public void handleOrder(Order order){
        Console.WriteLine("CentralNode received order: \n" + order.ToString());
        if(!this.orders.ContainsKey(order.Id))
            this.orders.Add(order.Id, order);
        this.OrderEvent(order.OrderParts);
    }

    public void changeOrderPartStatus(int orderID, int orderPartID, string status){
        this.orders[orderID].changeOrderPartStatus(orderPartID, status);
        if (this.orders[orderID].isReady()){
            this.OrderReadyEvent(this.orders[orderID]);
        }
    }

    public void servedOrder(int orderID){
        if(this.orders.ContainsKey(orderID)){
            Console.WriteLine("\r\n\r\nOrder no " + orderID + " is ready was served.\r\n\r\n");
            this.OrderServedEvent(this.orders[orderID]);
        }
    }

    public void paidOrder(int orderID){
        if(this.orders.ContainsKey(orderID)){
            Console.WriteLine("\r\n\r\nOrder no " + orderID + " was paid.\r\n\r\n");
            Console.WriteLine(this.orders[orderID].Invoice());
            this.orders[orderID].Paid = true;    
        }
    }
}