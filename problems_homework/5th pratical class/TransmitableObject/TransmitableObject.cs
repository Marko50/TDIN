using System;

[Serializable]
public class TransmitableObject{

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
}