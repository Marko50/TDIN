using System;

//=====Information to pass to the event handlers==========
// By convention event delegates and subscribers should 
// send and receive parameters inside a class derived from
// EventArgs (in the framework) and with a name suffix also
// containing ...EventArgs

class InventoryEventArgs : EventArgs {
  public string PName { get; set; }
  public int NrChange { get; set; }
  
  public InventoryEventArgs(string pname, int change) {
    PName = pname;
    NrChange = change;
  }
};

//=====The class who fires an event======================
// By convention the first parameter in an event handler
// should be the source object who fired the event

class InventoryManager {
  public delegate void InventoryChangeHandler(object source, InventoryEventArgs e);   // the delegate associated with the event
  public event InventoryChangeHandler OnChange;
  
  public void UpdateInventory(string pname, int change) {
    if (change == 0)
      return;
    InventoryEventArgs e = new InventoryEventArgs(pname, change);
    if (OnChange != null) {  // call only if they are subscribers
      Console.WriteLine("[UpdateInventory]: Number of \"{0}\" modifyed by {1} units.", pname, change);
      Console.WriteLine("[UpdateInventory]: Raising event ...");
      OnChange(this, e);
    }
  }
};

//=====The class who subscribes the event================

class Watcher {
  public Watcher(InventoryManager invm) {
    Console.WriteLine("[Watcher]: Subscribing event OnChange ...");
    invm.OnChange += Handler;
  }
  
  public void Handler(object sender, InventoryEventArgs e) {
    Console.WriteLine("[Watcher]: Part {0} was {1} by {2} units.", e.PName,
                      e.NrChange > 0 ? "increased" : "decreased", Math.Abs(e.NrChange));
  }
};

//========================================================

class App {
  public static void Main() {
    InventoryManager im = new InventoryManager();
    Watcher w = new Watcher(im);
    Console.WriteLine("InventoryManager and Watcher instanciated ...");
    
    Console.ReadLine();
    im.UpdateInventory("111 006 116", -2);
    Console.ReadLine();
    im.UpdateInventory("111 005 283", 10);
    Console.ReadLine();
    Console.WriteLine("End.");
  }
}