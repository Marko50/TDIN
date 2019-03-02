// Just a skeleton of the remote class
// for satisfying the compiler verifier and the remote configurator

using System;

public class Remote: MarshalByRefObject {
  public string Hello() {
    return null;
  }

  public string Modify(ref int val) {
    return null;
  }
}
