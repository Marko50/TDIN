using System;

[Serializable]
public class OrderPart{
    public static int count = 0;
    private int id;
    private int orderId;
    private string description = "Teste";
    private int quantity = 1;
    private string type = "Bar";
    private string state = "Not Picked"; //(‘not  picked’,  ‘inpreparation’,‘ready’, and ‘paid’)

     public int Id{
        get{
            return this.id;
        }
        set{
            this.id = value;
        }
    }

    public int OrderId{
        get{
            return this.orderId;
        }
        set{
            this.orderId = value;
        }
    }

    public string Description{
        get{
            return this.description;
        }
        set{
            this.description = value;
        }
    }
    
    public int Quantity{
        get{
            return this.quantity;
        }
        set{
            this.quantity = value;
        }
    }

    public string Type{
        get{
            return this.type;
        }
        set{
            this.type = value;
        }
    }


    public string State{
        get{
            return this.state;
        }
        set{
            this.state = value;
        }
    }

    public OrderPart(int id){
        this.orderId = id;
        this.id = count;
        count++;
    }

    public override string ToString(){
        return "\r\n\r\nOrderPart no " + this.id + " from order no" + this.orderId + "\nDescription: " + this.description + "\nQuantity: " 
        + this.quantity + "\nType: " + this.type + "\nState: "  + this.state + "\r\n\r\n";
    }

    public string Invoice(){
        return "\t" + this.description + " x" + this.quantity + "\n";
    }
}