using System;
using System.Runtime.Remoting;
using System.Windows.Forms;
using System.Collections.Generic;


public class PaymentManager : MarshalByRefObject{
    private PaymentGUI gui = new PaymentGUI();
    private CentralNodeManager centralNode = new CentralNodeManager();
    private Dictionary<int, Order> orders = new Dictionary<int, Order>();
    public static void Main(){
        RemotingConfiguration.Configure("src/Servers/Payment/PaymentManager.exe.config", false);
        PaymentManager paymentManager = new PaymentManager();
        Application.Run(paymentManager.gui);
        paymentManager.centralNode.OrderServedEvent -= paymentManager.handleServedOrder;
        paymentManager.gui.OrderStatusEvent += paymentManager.handleOrderStatusPaid;
    }

    public PaymentManager(){
        this.centralNode.OrderServedEvent += this.handleServedOrder;
        this.gui.OrderStatusEvent += this.handleOrderStatusPaid;
    }

    private void handleServedOrder(Order order){
        if(!this.orders.ContainsKey(order.Id)){
            Console.WriteLine("\r\n\r\n Order no " + order.Id + " has been served and awaiting payment.\r\n\r\n");
            this.orders.Add(order.Id, order);
            this.gui.addServedOrder(order.Id, "Total price " + order.Price.ToString() + " from table " + order.DestinationTable.ToString());
        }
    }

    private void handleOrderStatusPaid(int orderID){
        if(this.orders.ContainsKey(orderID)){
            Console.WriteLine("\r\n\r\nOrder no " + orderID + " was paid.\r\n\r\n");
            this.orders[orderID].Paid = true;
            this.centralNode.paidOrder(orderID);
        }
    } 

}