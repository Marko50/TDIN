using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

public class PaymentGUI : Form{
    List<Control> controls = new List<Control>();
    private ServedOrders servedOrders;

    public delegate void OrderStatusHandler(int orderId);
    public event OrderStatusHandler OrderStatusEvent;

    public void ActivatedHandler(object sender, EventArgs e){
        this.reload();
    }

    public PaymentGUI(){
        BackColor = Color.Silver;
        Text = "Payment Zone";
        Size = new Size(600,400);
        this.servedOrders = new ServedOrders(25,25);
        this.Activated += this.ActivatedHandler;
    }


    private void removeControls(){
        foreach (Control item in this.controls){
            this.Controls.Remove(item);
        }
        this.controls.Clear();
    }

    private void reload(){
        this.Focus();
        this.removeControls();
        this.servedOrders.setupControls(this);
        Application.DoEvents();
        foreach (Control item in this.controls){
            item.Refresh();
        }
    }

    public void addServedOrder(int orderID, string desc){
        this.servedOrders.addOrder(orderID, desc);
        this.reload();
    }

    public void ButtonClick(object sender, EventArgs e){
        Button button = sender as Button;
        Label label = button.Tag as Label;
        int id = (int) label.Tag;
        this.OrderStatusEvent(id);
        this.servedOrders.removeOrder(id);
        this.reload();
    }

    private class ServedOrders{
        private int x,y;
        protected Dictionary<int,string> orders = new Dictionary<int, string>(); // orderid, description

        public ServedOrders(int startX, int startY){
            this.x=startX;
            this.y=startY;
        }

        public void setupControls(PaymentGUI parent){
            Label text = new Label();
            text.Text = "Orders Served";
            text.Parent = parent;
            text.BorderStyle = BorderStyle.FixedSingle;
            text.Font = new Font("Arial", 14, FontStyle.Bold);
            text.BackColor = Color.SkyBlue;
            text.Location = new Point(this.x, this.y);
            text.AutoSize = true;
            parent.Controls.Add(text);
            parent.controls.Add(text);
            int i = 0;
            foreach (KeyValuePair<int,string> item in this.orders)
            {
                Label order = new Label();
                order.Tag = item.Key;
                order.Parent = parent;
                order.Text = item.Key + " : " + item.Value;
                order.BorderStyle = BorderStyle.FixedSingle;
                order.Font = new Font("Arial", 14, FontStyle.Bold);
                order.BackColor = Color.SkyBlue;
                order.Location = new Point(this.x, this.y + text.Height*(i+1) + 10);
                order.AutoSize = true;
                parent.Controls.Add(order);
                parent.controls.Add(order);

                Button button = new Button();
                button.Parent = parent;
                button.Text = "PAID";
                button.BackColor = Color.SkyBlue;
                button.Location = new Point(this.x + order.Width + 10 , this.y + text.Height*(i+1) + 10);
                button.Size = new Size(40,20);
                button.Tag = order;
                button.Click += new EventHandler(parent.ButtonClick);
                parent.Controls.Add(button);
                parent.controls.Add(button);
                i++;
            } 
        }

        public void addOrder(int orderID, string description){
            if(!this.orders.ContainsKey(orderID))
                this.orders.Add(orderID, description);
        }
        public void removeOrder(int id){
            if(this.orders.ContainsKey(id))
                this.orders.Remove(id);
        }
    }
}