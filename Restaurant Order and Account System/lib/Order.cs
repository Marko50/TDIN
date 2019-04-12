using System;
using System.Collections.Generic;

[Serializable]
public class Order{
    public static int count = 0;
    
    private int id;
    private int destinationTable = 1;

    List<OrderPart> orderParts = new List<OrderPart>();

    public int Id{
        get{
            return this.id;
        }
        set{
            this.id = value;
        }
    }

    public int DestinationTable{
        get{
            return this.destinationTable;
        }
        set{
            this.destinationTable = value;
        }
    }

    public List<OrderPart> OrderParts{
        get{
            return this.orderParts;
        }
    }

    public void addOrderPart(OrderPart orderPart){
        this.orderParts.Add(orderPart);
    }


    public Order(){
        this.id = count;
        count++;
        OrderPart orderPartFirst = new OrderPart(this.id);
        OrderPart orderPartSecond = new OrderPart(this.id);
        OrderPart orderPartThird = new OrderPart(this.id);
        orderPartSecond.Type = "Kitchen";
        orderPartThird.Type = "Kitchen";
        this.orderParts.Add(orderPartFirst);
        this.orderParts.Add(orderPartSecond);
        this.orderParts.Add(orderPartThird);
    }

    public override string ToString(){
        string ret = "";
        foreach (OrderPart orderPart in this.orderParts)
            ret += orderPart.ToString();
        return "\r\n\r\nOrder no " + this.id  + "\nFor table: " + this.destinationTable + "\r\n\r\n" + ret;
    }

    public void changeOrderPartStatus(int orderPartID, string status){
        foreach (OrderPart orderPart in this.orderParts)
            if(orderPart.Id.Equals(orderPartID)){
                orderPart.State = status;
                Console.WriteLine(orderPart.ToString() + " has changed status to " + status);
            }
    }
}