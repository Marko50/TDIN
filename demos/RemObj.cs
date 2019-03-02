using System;

public class RemClass: MarshalByRefObject {
  public RemClass() {
    Console.WriteLine("Constructor called");
  }

  public string Modify(/* ref */ int[] val) {
    Console.WriteLine("Modify called");
    Console.WriteLine("[Modify]: Array received: val[0] = {0}, val[1] = {1}", val[0], val[1]);
    val[0] *= 2;
    val[1] *= 2;
    Console.WriteLine("[Modify]: Array modified: val[0] = {0}, val[1] = {1}", val[0], val[1]);
    return "Modify returned";
  }
}
