using System;
using System.Runtime.Remoting;

public class Server{
    public static void Main(){
        RemotingConfiguration.Configure("Server.exe.config", false);
        Console.WriteLine("[Server] hosting InventoryManager");
        Console.WriteLine("Press Enter to exit");
        Console.ReadLine();
    }
}