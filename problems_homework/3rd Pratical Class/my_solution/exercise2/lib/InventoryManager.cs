using System;
using System.Collections.Generic;

public class InventoryManager : MarshalByRefObject{
    delegate void InventoryChangeHandler(Object sender, InventoryChangeArgs info);
    private event InventoryChangeHandler InventoryChangeEvent;
    private Dictionary<string,int> parts;

    private void handler(Object sender, InventoryChangeArgs info){
        info.handler();
    }
    public InventoryManager(){
        this.parts = new Dictionary<string,int>();
        this.InventoryChangeEvent += new InventoryChangeHandler(this.handler);
    }

    public void UpdateInventory(string pno, int change){
        this.InventoryChangeEvent(new Object(), new InventoryChangeArgs(pno,change));
        if (this.parts.ContainsKey(pno)){
            this.parts[pno] += change;
        }
        else{
            this.parts.Add(pno,change);
        }
    }
}