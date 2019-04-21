using System;
using System.Runtime.Remoting;
using System.Windows.Forms;
using System.Collections.Generic;

public class DiningRoom : MarshalByRefObject {
    private DiningRoomGUI gui = new DiningRoomGUI();
    private CentralNodeManager centralNode = new CentralNodeManager();
    
    [STAThread]
    public static void Main(){
        RemotingConfiguration.Configure("Clients/DiningRoom/DiningRoom.exe.config",false);
        DiningRoom diningRoom = new DiningRoom();  
        Application.Run(diningRoom.gui);
        diningRoom.centralNode.OrderReadyEvent -= diningRoom.handleReadyOrder;
        diningRoom.gui.MakeOrderEvent -= diningRoom.MakeOrder;
        diningRoom.gui.ServeOrderEvent -= diningRoom.handleServedOrder;
    }

    public DiningRoom(){
        this.gui.MakeOrderEvent += this.MakeOrder;
        this.gui.ServeOrderEvent += this.handleServedOrder;
        this.centralNode.OrderReadyEvent += this.handleReadyOrder;
    }

    private void MakeOrder(string table, float price, Dictionary<string,string>[] information){
        Order order = new Order();
        order.DestinationTable = int.Parse(table);
        order.Price = price;
        foreach (Dictionary<string,string> item in information){
            OrderPart orderPart = new OrderPart(order.Id);
            orderPart.Description = item["description"];
            orderPart.Quantity = int.Parse(item["quantity"]);
            orderPart.Type = item["type"];
            order.addOrderPart(orderPart);
        }
        this.centralNode.handleOrder(order);
    }

    private void handleReadyOrder(Order order){
        Console.WriteLine("\r\n\r\nOrder no " + order.Id + " is ready to be picked.\r\n\r\n");
        this.gui.addReadyOrder(order.Id, "For table " + order.DestinationTable);
    }

    private void handleServedOrder(int orderID){
        Console.WriteLine("\r\n\r\nOrder no " + orderID + " is ready was served.\r\n\r\n");
        this.centralNode.servedOrder(orderID);
    }
}