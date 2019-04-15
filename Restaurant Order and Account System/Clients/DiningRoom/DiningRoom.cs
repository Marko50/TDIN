using System;
using System.Runtime.Remoting;
using System.Windows.Forms;
using System.Collections.Generic;

public class DiningRoom : MarshalByRefObject {
    private DiningRoomGUI gui = new DiningRoomGUI();
    
    [STAThread]
    public static void Main(){
        RemotingConfiguration.Configure("Clients/DiningRoom/DiningRoom.exe.config",false);
        CentralNodeManager centralNode = new CentralNodeManager();
        DiningRoom diningRoom = new DiningRoom();
        centralNode.OrderReadyEvent += diningRoom.handleReadyOrder;
        Application.Run(diningRoom.gui);
        centralNode.OrderReadyEvent -= diningRoom.handleReadyOrder;
    }

    public DiningRoom(){
        this.gui.MakeOrderEvent += this.MakeOrder;
    }

    private void MakeOrder(string table, float price, Dictionary<string,string>[] information){
        RemotingConfiguration.Configure("Clients/DiningRoom/DiningRoom.exe.config",false);
        CentralNodeManager centralNode = new CentralNodeManager();
        DiningRoom diningRoom = new DiningRoom();
        centralNode.OrderReadyEvent += diningRoom.handleReadyOrder;
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
        centralNode.handleOrder(new Order());
    }

    private void handleReadyOrder(int orderID){
        Console.WriteLine("\r\n\r\nOrder no " + orderID + " is ready to be picked.\r\n\r\n");
    }
}