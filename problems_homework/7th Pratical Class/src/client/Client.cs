using System;
using System.ServiceModel;
public class Client{
    public static void Main(){
        ChannelFactory<IHostService> chFactory= new ChannelFactory<IHostService> (new NetMsmqBinding(),new EndpointAddress("net.msmq://localhost/" + HostService.QUEUE_NAME) );
        IHostService svc= chFactory.CreateChannel();
        svc.ServiceMethodCall("Random Parameter");
    }
}