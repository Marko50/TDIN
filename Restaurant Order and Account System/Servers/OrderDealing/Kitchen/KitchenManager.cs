using System;
using System.Runtime.Remoting;
using System.Windows.Forms;
using System.Collections.Generic;


public class KitchenManager : OrderDealing{
    public KitchenManager() : base(){
        this.gui = new KitchenGUI();
        this.gui.OrderPartStatusEvent += this.changeOrderStatus;
        this.type = "Kitchen";
    }
    public static void Main(){
        RemotingConfiguration.Configure("Servers/OrderDealing/Kitchen/KitchenManager.exe.config", false);
        KitchenManager kitchen = new KitchenManager();
        Application.Run(kitchen.gui);
        kitchen.unlinkEvents();
    }
}