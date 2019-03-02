using System;

namespace Shared {
  public delegate void InventoryChangeHandler(InventoryChangeArgs pars);

  [Serializable]
  public class InventoryChangeArgs : EventArgs {
    public string Pno { get; set; }
    public int Change { get; set; }

    public InventoryChangeArgs(string pno, int change) {
      Pno = pno;
      Change = change;
    }
  }
}
