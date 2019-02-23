using System;

//=====Information to pass to the event handlers==========

class InventoryEventArgs : EventArgs {
  public string PName {get; set;}
  public int NrChange {get; set;}
  
  public InventoryEventArgs(string pname, int change) {
    PName = pname;
    NrChange = change;
  }
};

//=====The class who fires an event======================

class InventoryManager {
  public delegate void InventoryChangeHandler(object source, InventoryEventArgs e);
  public event InventoryChangeHandler ChangeEvent;
  
  public void UpdateInventory(string pname, int change) {
    if (change == 0)
      return;
    InventoryEventArgs e = new InventoryEventArgs(pname, change);
    if (ChangeEvent != null) {
      Console.WriteLine("[UpdateInventory]: Raising event ...");
      ChangeEvent(this, e);
    }
  }
};

//=====The class who subscribes the event================

class Watcher {
  public Watcher(InventoryManager invm) {
    Console.WriteLine("[Watcher]: Subscribing event ChangeEvent ...");
    invm.ChangeEvent += Handler;
  }
  
  public void Handler(object o, InventoryEventArgs e) {
    Console.WriteLine("[Watcher]: Part {0} was {1} by {2} units.", e.PName,
                      e.NrChange > 0 ? "increased" : "decreased", Math.Abs(e.NrChange));
  }
};

//=====Another class that subscribes the event================

class Logger {
  public Logger(InventoryManager invman) {
    Console.WriteLine("[Logger]: Subscribing event ChangeEvent ...");
    invman.ChangeEvent += LogHandler;
  }
  
  public void LogHandler(object o, InventoryEventArgs e) {
    Console.WriteLine("[Logger]: Inventory of part {0} has changed.", e.PName);
  }
}

//========================================================

class App {
  public static void Main() {
    InventoryManager im = new InventoryManager();
    Watcher w = new Watcher(im);
    Logger l = new Logger(im);
    Console.WriteLine("InventoryManager and subscribers instanciated ...");
    
    Console.ReadLine();
    im.UpdateInventory("111 006 116", -2);
    Console.ReadLine();
    im.UpdateInventory("111 005 283", 10);
    Console.ReadLine();
    Console.WriteLine("End.");
  }
}