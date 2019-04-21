using System;
using System.Runtime.Remoting;
using System.Collections.Generic;

public abstract class OrderDealing : MarshalByRefObject{
    protected OrderDealingGUI gui;

    protected CentralNodeManager centralNode;
    protected string type; 
    private Dictionary <int, OrderPart> orders;

    public OrderDealing(){
        this.orders = new Dictionary<int, OrderPart>();
        this.centralNode = new CentralNodeManager();
        this.linkEvents();
    }

    public void unlinkEvents(){
        this.centralNode.OrderEvent -= this.handleOrder;
        this.gui.OrderPartStatusEvent -= this.changeOrderStatus;
    }

    public void linkEvents(){
        this.centralNode.OrderEvent += this.handleOrder;
    }

    protected void handleOrder(List<OrderPart> orderParts){
        foreach (OrderPart orderPart in orderParts)
        {
            if (orderPart.Type.Equals(this.type)){
                this.orders.Add(orderPart.Id, orderPart);
                this.gui.addOrderPartNotPicked(orderPart.Id, orderPart.Description + " x" + orderPart.Quantity);
                Console.WriteLine(this.type + " received: " + orderPart.ToString());
            }
        }
    }

    protected void changeOrderStatus(int orderPartID, string status){
        if (this.orders.ContainsKey(orderPartID)){
            this.orders[orderPartID].State = status;
            Console.WriteLine(this.type + ": " + this.orders[orderPartID].ToString() + " has changed status to " + status);    
        }
        this.centralNode.changeOrderPartStatus(this.orders[orderPartID].OrderId, orderPartID, status); 
    }
}