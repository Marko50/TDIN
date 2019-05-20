using System;
using System.ServiceModel;

public class HostService : IHostService{
    public static string QUEUE_NAME = "HostServiceMessageQueue";
    public void ServiceMethodCall(string param){
        Console.WriteLine("Param: " + param);
    }
}