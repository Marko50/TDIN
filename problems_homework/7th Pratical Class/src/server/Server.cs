using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Messaging;

public class Server{
    public static void Main(){
        if (!MessageQueue.Exists(HostService.QUEUE_NAME))
            MessageQueue.Create(HostService.QUEUE_NAME, true);
        ServiceHost shost = new ServiceHost(typeof(HostService), new Uri("http://localhost:8000/HostService"));
        ServiceMetadataBehavior metad = shost.Description.Behaviors.Find<ServiceMetadataBehavior>();
        if (metad == null)
          metad = new ServiceMetadataBehavior();
        metad.HttpGetEnabled = true;
        shost.Description.Behaviors.Add(metad);
        shost.AddServiceEndpoint(typeof(HostService), new NetMsmqBinding(), "net.msmq://localhost/" + HostService.QUEUE_NAME);
        shost.Open();
        Console.WriteLine("HOST service open. Press <ENTER> to terminate.");
        Console.ReadLine();
        shost.Close();
    }
}