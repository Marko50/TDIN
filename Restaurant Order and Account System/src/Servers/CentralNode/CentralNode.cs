using System;
using System.Runtime.Remoting;

public class CentralNode{
    public static void Main(){
        RemotingConfiguration.Configure("src/Servers/CentralNode/CentralNode.exe.config", false);
        Console.WriteLine("Central Node was opened! Press ENTER to close it!");
        Console.ReadLine();
    }
}