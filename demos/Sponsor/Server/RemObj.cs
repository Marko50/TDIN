using System;
using System.Runtime.Remoting.Lifetime;

public class RemObj: MarshalByRefObject
{
  public RemObj()
  {
    Console.WriteLine("Constructor called");
  }

  public override object InitializeLifetimeService()
  {
    ILease lease = (ILease) base.InitializeLifetimeService();
    if (lease.CurrentState == LeaseState.Initial) {
      lease.InitialLeaseTime = TimeSpan.FromSeconds(5);
      lease.RenewOnCallTime = TimeSpan.FromSeconds(3);
    }
    return lease;
  }

  public string Hello()
  {
    Console.WriteLine("Hello called");
    return "Hello .NET client!";
  }
}
