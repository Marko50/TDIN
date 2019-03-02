using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;

class Server
{
  static void Main(string[] args)
  {
    LifetimeServices.LeaseManagerPollTime = TimeSpan.FromSeconds(1);
    RemotingConfiguration.Configure("Server.exe.config");
    Console.WriteLine("Press return to exit");
    Console.ReadLine();
  }
}
