using System;
using System.Runtime.Remoting;

public class Kitchen{
    public static void Main(){
        RemotingConfiguration.Configure("Clients/Kitchen/Kitchen.exe.config",false);
        Console.WriteLine("About to call remote bar order change. Press Enter.");
        Console.ReadLine();
        // CentralNodeManager centralNode = new CentralNodeManager();
        // centralNode.changeOrderPartStatus(0,0, "Ready");
    }
}