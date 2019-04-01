using System;
using System.Runtime.Remoting;

public class OrderDealingCenter{
    public static void Main(){
        RemotingConfiguration.Configure("Server/OrderDealingCenter.exe.config", false);
        Console.WriteLine("OrderDealingCenter was opened! Press ENTER to close it!");
        Console.ReadLine();
    }
}