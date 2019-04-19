using System;
using System.Runtime.Remoting;
using System.Windows.Forms;
using System.Collections.Generic;


public class BarManager : OrderDealing{
    private BarGUI barGUI = new BarGUI();
    public BarManager() : base(){
        this.type = "Bar";
    }
    public static void Main(){
        RemotingConfiguration.Configure("Servers/OrderDealing/Bar/BarManager.exe.config", false);
        BarManager bar = new BarManager();
        CentralNodeManager centralNode = new CentralNodeManager();
        centralNode.OrderEvent += bar.handleOrder; 
        centralNode.OrderChangeEvent += bar.changeOrderStatus;
        Application.Run(bar.barGUI);
        centralNode.OrderEvent -= bar.handleOrder;
        centralNode.OrderChangeEvent -= bar.changeOrderStatus;
    }
}