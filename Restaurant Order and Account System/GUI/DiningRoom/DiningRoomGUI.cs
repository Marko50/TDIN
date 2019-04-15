using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

// DiningRoom diningRoom = new DiningRoom();
//             diningRoom.MakeOrder(table, orderTotalPrice, information);
public class DiningRoomGUI : Form{

    public delegate void MakeOrderHandler(string table, float price, Dictionary<string,string>[] information);
    public event MakeOrderHandler MakeOrderEvent;
    private Dictionary<string,int> currentOrder = new Dictionary<string, int>();
    private Dictionary<string, string> currentOrderTypes = new Dictionary<string, string>();

    private string table = "NONE";

    public string Table{
        set{
            this.table = value;
        }
    }
    private OrderTotal orderTotal;
    public DiningRoomGUI(){
        this.MakeOrderEvent += this.makeOrderHandler;
        BackColor = Color.Silver;
        Size = new Size(600,400);
        Text = "Dining Room";
        PurchaseOptions foods = new PurchaseOptions(this, 25, new string[]{"Arroz de Marisco : 15€", "Massa à labrador : 5€", "Prego em Prato : 5,5€"}, "Kitchen");
        PurchaseOptions drinks = new PurchaseOptions(this, 300, new string[]{"Cerveja : 1,5€", "Água : 1€", "Coca-Cola : 1,20€"}, "Bar");
        Tables tables = new Tables(this, 150, 8);
        this.orderTotal = new OrderTotal(this, 200);
        
    }

    public void ButtonClick(object sender, EventArgs e){
        Button button = sender as Button;
        Label label = button.Tag as Label;
        string text = label.Text;
        string type = (string) label.Tag;
        string[] textComponents = text.Split(":");
        string description = textComponents[0];
        string priceS = textComponents[1];
        float price = float.Parse(priceS.Remove(priceS.Length - 1, 1));
        string[] orderTotalComponents = this.orderTotal.text.Text.Split(":");
        string orderTotalPriceS = orderTotalComponents[1];
        float orderTotalPrice = float.Parse(orderTotalPriceS.Remove(orderTotalPriceS.Length - 1, 1));

        if(button.Text.Equals("+")){
            if(this.currentOrder.ContainsKey(description)){
                this.currentOrder[description] = this.currentOrder[description] + 1;
            }
            else{
                this.currentOrderTypes[description] = type;
                this.currentOrder[description] = 1;
            }
            string s = "";
            foreach (KeyValuePair<string, int> item in this.currentOrder){
                s+= item.Key + " x" + item.Value;
            }
            s+= this.table.Equals("NONE") ? "" : " for table " + this.table;
            this.orderTotal.setText("Order Total: " + (orderTotalPrice + price) + "€:" + s);
        }
        else if(button.Text.Equals("-")){
            if(this.currentOrder.ContainsKey(description)){
                if(this.currentOrder[description] - 1 != 0){
                    this.currentOrder[description] = this.currentOrder[description] - 1;
                }
                else{
                    this.currentOrder.Remove(description);
                    this.currentOrderTypes.Remove(description);
                }
                string s = "";
                foreach (KeyValuePair<string, int> item in this.currentOrder){
                    s+= item.Key + " x" + item.Value;
                }
                s+= this.table.Equals("NONE") ? "" : " for table " + this.table;
                this.orderTotal.setText("Order Total: " + (orderTotalPrice - price) + "€:" + s);
            }
        }
        
    }

    public void MakeOrder(object sender, EventArgs e){
        if(this.currentOrder.Count > 0 && !this.table.Equals("NONE")){
            string[] orderTotalComponents = this.orderTotal.text.Text.Split(":");
            string orderTotalPriceS = orderTotalComponents[1];
            float orderTotalPrice = float.Parse(orderTotalPriceS.Remove(orderTotalPriceS.Length - 1, 1));
            Dictionary<string,string>[] information = new Dictionary<string, string>[this.currentOrder.Count];
            int count = 0;
            foreach (KeyValuePair<string, int> item in this.currentOrder){
                Dictionary<string,string> unit = new Dictionary<string, string>();
                unit["description"] = item.Key;
                unit["quantity"] = item.Value.ToString();
                unit["type"] = this.currentOrderTypes[item.Key];
                information[count] = unit;
                count++;
            }
            Console.WriteLine("F TO PAY RESPECTS");
            this.MakeOrderEvent(this.table, orderTotalPrice, information);
            Console.WriteLine("respects were payed");
            this.currentOrder.Clear();
            this.currentOrderTypes.Clear();
            this.orderTotal.setText("Order Total : 0€:");
            this.table = "NONE";
        }
    }

    private void makeOrderHandler(string table, float price, Dictionary<string,string>[] information){}


    private class PurchaseOptions
    {
        public PurchaseOptions(DiningRoomGUI parent, int startX, string[] opts, string type){
            for (int i = 0; i < opts.Length; i++){
                Label text = new Label();
                text.Tag = type;
                text.Parent = parent;
                text.Text = opts[i];
                text.BorderStyle = BorderStyle.FixedSingle;
                text.Font = new Font("Arial", 14, FontStyle.Bold);
                text.BackColor = Color.SkyBlue;
                text.Location = new Point(startX, 25 + 40*i);
                text.AutoSize = true;

                Button button = new Button();
                button.Text = "+";
                button.Parent = parent;
                button.BackColor = Color.SkyBlue;
                button.Location = new Point(startX + text.Width + 10 , 25 + 40*i);
                button.Size = new Size(20,20);
                button.Tag = text;
                button.Click += new EventHandler(parent.ButtonClick);
                parent.Controls.Add(button);

                Button button2 = new Button();
                button2.Text = "-";
                button2.Parent = parent;
                button2.BackColor = Color.SkyBlue;
                button2.Location = new Point(startX + text.Width + button.Width + 10 , 25 + 40*i);
                button2.Size = new Size(20,20);
                button2.Tag = text;
                button2.Click += new EventHandler(parent.ButtonClick);
                parent.Controls.Add(button2);
            }
        }   
    }

    private class OrderTotal{
        public Label text;

        public void setText(string t){
            this.text.Text = t;
        }

        public OrderTotal(DiningRoomGUI parent, int startY){
            this.text = new Label();
            this.text.Parent = parent;
            this.text.Text = "Order Total : 0€:";
            this.text.BorderStyle = BorderStyle.FixedSingle;
            this.text.Font = new Font("Arial", 14, FontStyle.Bold);
            this.text.BackColor = Color.SkyBlue;
            this.text.Location = new Point(25, startY);
            this.text.AutoSize = true;

            Button button = new Button();
            button.Text = "Make Order";
            button.Parent = parent;
            button.BackColor = Color.SkyBlue;
            button.Location = new Point(25 , startY + this.text.Height + 10);
            button.Size = new Size(70,40);
            button.Click += new EventHandler(parent.MakeOrder);
            parent.Controls.Add(button);
        }
    }

    private class Tables{

        CheckBox ticked = null;
       
        public Tables(DiningRoomGUI parent, int startY, int numTables){
            for (int i = 0; i < numTables; i++)
            {
                // Create and initialize a CheckBox.   
                CheckBox checkBox1 = new CheckBox(); 
                // Make the check box control appear as a toggle button.
                checkBox1.Appearance = Appearance.Button;
                // Turn off the update of the display on the click of the control.
                //checkBox1.AutoCheck = false;
                checkBox1.Text = "Table " + (i + 1).ToString();
                checkBox1.Parent = parent;
                checkBox1.Click += new EventHandler(this.checkBoxHandler);
                checkBox1.Size = new Size(40,40);
                checkBox1.Location = new Point(25 + 50*i, startY);
                checkBox1.BackColor = Color.SkyBlue;
                parent.Controls.Add(checkBox1);
            }
            
        }

        private void checkBoxHandler(object sender, EventArgs e){
            CheckBox check = sender as CheckBox;
            DiningRoomGUI parent = check.Parent as DiningRoomGUI;
            if(ticked!= null){
                ticked.Checked = false;
                check.Checked = true;
                ticked = check;
            }
            else{
                ticked = check;
                check.Checked = true;
            }
            parent.Table = check.Text.Split(" ")[1];
        }
    }

}