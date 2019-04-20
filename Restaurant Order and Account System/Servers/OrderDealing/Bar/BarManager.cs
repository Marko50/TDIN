using System;
using System.Runtime.Remoting;
using System.Windows.Forms;
using System.Collections.Generic;


public class BarManager : OrderDealing{
    
    public BarManager() : base(){
        this.type = "Bar";
        this.gui = new BarGUI();
        this.gui.OrderPartStatusEvent += this.changeOrderStatus;
    }
    public static void Main(){
        RemotingConfiguration.Configure("Servers/OrderDealing/Bar/BarManager.exe.config", false);
        BarManager bar = new BarManager();
        Application.Run(bar.gui);
        bar.unlinkEvents();
    }
}