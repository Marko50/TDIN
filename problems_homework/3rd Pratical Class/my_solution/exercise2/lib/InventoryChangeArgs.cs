using System;
using System.IO;

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

    public void watch(){
         StreamWriter file = new StreamWriter("../InventoryWatcher/watcher.txt", true);//append = true
         string line = "Inventory of part " + this.pno + " was ";
         if(this.change > 0){
             line += "increased by " + this.change + " units.";
         }
         else if (this.change < 0){
             line += "decreased by " + this.change + " units.";
         }
         else{
             line += "unchanged.";
         }
         file.WriteLine(line);
         file.Close();
    }
}