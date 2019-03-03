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
    public void log(){
        if(this.change > 0){
             Console.WriteLine("Inventory of part " + this.pno + " was increased by " + this.change.ToString() + " units");
         }
         else if (this.change < 0){
             Console.WriteLine("Inventory of part " + this.pno + " was decreased by " + this.change.ToString() + " units");
         }
         else{
             Console.WriteLine("Inventory of part " + this.pno + " was unchanged");
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