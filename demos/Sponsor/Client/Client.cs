using System;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;

class Client
{
  static void Main()
  {
    RemotingConfiguration.Configure("Client.exe.config");
    RemObj obj = new RemObj();
    ClSponsor sponsor = new ClSponsor();
    sponsor.RenewalTime = TimeSpan.FromSeconds(5);
    sponsor.Register(obj);

    Console.WriteLine(obj.Hello());
    Console.ReadLine();
    Console.WriteLine(obj.Hello());
    Console.ReadLine();
    
    sponsor.Unregister(obj);
  }
}

public class ClSponsor : ClientSponsor, ISponsor
{
  TimeSpan ISponsor.Renewal(ILease lease)
  {
    Console.WriteLine("Renewal called");
    return RenewalTime;
  }
}
