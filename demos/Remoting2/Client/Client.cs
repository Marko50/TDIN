using System;
using System.Runtime.Remoting;

class Client {
  static void Main() {
    int[] v = { 7, 8 };

    RemotingConfiguration.Configure("Client.exe.config", false);
    RemClass obj = new RemClass();

    Console.WriteLine("Original array: v[0] = {0}  v[1] = {1}", v[0], v[1]);
    Console.WriteLine(ModifyLocal(v));
    Console.WriteLine("After local modification: v[0] = {0}  v[1] = {1}", v[0], v[1]);
    Console.ReadLine();
    Console.WriteLine(obj.Modify(/* ref */ v));
    Console.WriteLine("After remote call: v[0] = {0}  v[1] = {1}", v[0], v[1]);
    Console.ReadLine();
  }

  static string ModifyLocal(int[] val) {
    val[0] += 10;
    val[1] += 10;
    return "ModifyLocal returned";
  }
}
