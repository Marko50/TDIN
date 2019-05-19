using System;
using PrimeNumberService;
using System.ServiceModel;

public class Client{
    static void Main(string[] args) {
        ChannelFactory<PrimeNumberInterface> chFactory= new ChannelFactory<PrimeNumberInterface> (new BasicHttpBinding(),new EndpointAddress("http://localhost:8000/PrimeNumberService/IPrimeNumberService") );
        PrimeNumberInterface svc= chFactory.CreateChannel();
        int response = svc.getNumberOfPrimeNumbers(100);
        Console.WriteLine("Response: " + response);
    }    
}
