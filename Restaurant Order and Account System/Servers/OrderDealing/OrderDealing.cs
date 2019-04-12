using System;
using System.Runtime.Remoting;
using System.Collections.Generic;

public abstract class OrderDealing : MarshalByRefObject{
    protected string type; 
    private Dictionary <int, OrderPart> orders;

    public OrderDealing(){
        this.orders = new Dictionary<int, OrderPart>();
    }

    protected void handleOrder(List<OrderPart> orderParts){
        foreach (OrderPart orderPart in orderParts)
            if (orderPart.Type.Equals(this.type))
            {
                this.orders.Add(orderPart.Id, orderPart);
                Console.WriteLine(this.type + " received: " + orderPart.ToString());
            }
    }

    protected void changeOrderStatus(int orderPartID, string status){
        if (this.orders.ContainsKey(orderPartID))
        {
            this.orders[orderPartID].State = status;
            Console.WriteLine(this.type + ": " + this.orders[orderPartID].ToString() + " has changed status to " + status);    
        }
        
    }
}