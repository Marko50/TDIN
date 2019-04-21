using System;
using System.Runtime.Remoting;
using System.Collections.Generic;


public class PaymentManager : MarshalByRefObject{
    //TODO: future gui
    private CentralNodeManager centralNode = new CentralNodeManager();
    private Dictionary<int, Order> orders = new Dictionary<int, Order>();
    public static void Main(){
        RemotingConfiguration.Configure("Servers/Payment/PaymentManager.exe.config", false);
        PaymentManager paymentManager = new PaymentManager();
        Console.WriteLine("Payment Manager has started. Click ENTER to close it.");
        Console.ReadLine();
        paymentManager.centralNode.OrderServedEvent -= paymentManager.handleServedOrder;
    }

    public PaymentManager(){
        this.centralNode.OrderServedEvent += this.handleServedOrder;
    }

    private void handleServedOrder(Order order){
        if(!this.orders.ContainsKey(order.Id)){
            Console.WriteLine("\r\n\r\n Order no " + order.Id + " has been served and awaiting payment.\r\n\r\n");
            this.orders.Add(order.Id, order);
        }
    }   

}