using System;

[Serializable]
public class InventoryChangeArgs : EventArgs {
    private string pno;
    private int change;
    public InventoryChangeArgs(string p, int ch){
        this.pno = p;
        this.change = ch;
    }
    public void handler(){
        if(this.change.Equals(0)){
            Console.WriteLine("WARNING: You are changing part " + this.pno + " with a value = 0");
        }
        else{
            Console.WriteLine("You are changing part " + this.pno + " with a value = " + this.change.ToString());
        }
    }
}