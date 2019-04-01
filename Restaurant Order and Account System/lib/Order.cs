using System;


[Serializable]
public class Order{
    public static int count = 0;
    
    private int id;
    private string description = "Teste";
    private int quantity = 1;
    private int destinationTable = 1;
    private string type = "Bar";
    private int price = 1;
    private string state = "Ready";

    public int Id{
        get{
            return this.id;
        }
        set{
            this.id = value;
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

    public int DestinationTable{
        get{
            return this.destinationTable;
        }
        set{
            this.destinationTable = value;
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

    public int Price{
        get{
            return this.price;
        }
        set{
            this.price = value;
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

    public Order(){
        this.id = count;
        count++;
    }

    public override string ToString(){
        return "Order no " + this.id + "\nDescription: " + this.description + "\nQuantity: " + this.quantity 
        + "\nFor table: " + this.destinationTable + "\nType: " + this.type + "\nPrice: " + this.price + "\nState: " 
        + this.state + "\r\n\r\n";
    }

    
}