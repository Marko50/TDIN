using System;
using WebWCFClient.MachineServiceReference;

namespace WebWCFClient {
  class Program {
    static void Main(string[] args) {
      MachineService proxy = new MachineService();
      string serverName = proxy.getMachineNameAndOS();
      Console.WriteLine("Server: " + serverName);
      Console.ReadLine();
    }
  }
}
