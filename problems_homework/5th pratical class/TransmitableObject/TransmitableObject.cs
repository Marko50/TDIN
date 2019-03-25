using System;

[Serializable]
public class TransmitableObject{
    public static string QUEUE_NAME = "SenderQueue";

    private static int count = 0;

    private int id;
    private string name;
    public int Id {
        get{
            return this.id;
        }
        set{
            this.id = value;
        }
    }
    public string Name{
        get{
            return this.name;
        }
        set{
            this.name = value;
        }
    }

    public TransmitableObject(string n){
        this.id = count;
        count++;
        this.name = n;
    }

    public override string ToString(){
        return "Transmitable Object no " + this.id + " with name " + this.name;
    }
}