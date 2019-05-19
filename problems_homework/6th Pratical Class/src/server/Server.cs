using System.ServiceModel;
using System.ServiceModel.Description;
using System;

public class Server{
    public static void Main(){
        ServiceHost shost = new ServiceHost(typeof(PrimeNumberService.IPrimeNumberService), new Uri("http://localhost:8000/PrimeNumberService/IPrimeNumberService"));
        ServiceMetadataBehavior metad = shost.Description.Behaviors.Find<ServiceMetadataBehavior>();
        if (metad == null)
          metad = new ServiceMetadataBehavior();
        metad.HttpGetEnabled = true;
        shost.Description.Behaviors.Add(metad);
        //shost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexNamedPipeBinding(), "http://localhost:9000/PrimeNumberService/IPrimeNumberService/");
        //shost.AddServiceEndpoint(typeof(PrimeNumberService.IPrimeNumberService), new NetTcpBinding(), "net.tcp://localhost:8000/PrimeNumberService/IPrimeNumberService/");
        shost.AddServiceEndpoint(typeof(PrimeNumberService.IPrimeNumberService), new BasicHttpBinding(), "http://localhost:8000/PrimeNumberService/IPrimeNumberService");
        shost.Open();
        Console.WriteLine("Prime number service open. Press <ENTER> to terminate.");
        Console.ReadLine();
        shost.Close();
    }
}