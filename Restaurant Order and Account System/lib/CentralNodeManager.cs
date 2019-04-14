using System;
using System.Runtime.Remoting;
using System.Collections.Generic;

public class CentralNodeManager : MarshalByRefObject{
    private Dictionary <int, Order> orders;
    public delegate void OrderHandler(List<OrderPart> order);
    public event OrderHandler OrderEvent;

    public delegate void OrderChangeHandler(int orderPartID, string status);
    public event OrderChangeHandler OrderChangeEvent;

    public delegate void OrderReadyHandler(int orderID);
    public event OrderReadyHandler OrderReadyEvent;

    private void handler(List<OrderPart> order){}

    private void changeHandler(int orderPartID, string status){}

    private void readyHandler(int orderID){}

    public CentralNodeManager(){
        this.orders = new Dictionary<int, Order>();
        this.OrderEvent += this.handler;
        this.OrderChangeEvent += this.changeHandler;
        this.OrderReadyEvent += this.readyHandler;
    }

    public void handleOrder(Order order){
        Console.WriteLine("CentralNode received order: \n" + order.ToString());
        if(!this.orders.ContainsKey(order.Id))
            this.orders.Add(order.Id, order);
            
        this.OrderEvent(order.OrderParts);
    }

    public void changeOrderPartStatus(int orderID, int orderPartID, string status){
        this.orders[orderID].changeOrderPartStatus(orderPartID, status);
        this.OrderChangeEvent(orderPartID, status);
        if (this.orders[orderID].isReady()){
            this.OrderReadyEvent(orderID);
        }
    }
}