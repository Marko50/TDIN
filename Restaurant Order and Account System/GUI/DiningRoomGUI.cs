using System;
using System.Windows.Forms;
using System.Drawing;
public class DiningRoomGUI : Form{
    [STAThread]
    public static void Main(){
        Application.Run(new DiningRoomGUI());
    }
    public DiningRoomGUI(){
        BackColor = Color.Silver;
        Size = new Size(600,400);
        Text = "Dining Room";
        PurchaseOptions foods = new PurchaseOptions(this, 25, new string[]{"Carneiro", "Tua mae", "riperino"});
        PurchaseOptions drinks = new PurchaseOptions(this, 400, new string[]{"Dar tudo", "Praxe e merda", "Perdi o jogo"});
    }

    private class PurchaseOptions
    {
        public PurchaseOptions(Form parent, int startX, string[] opts){
            for (int i = 0; i < opts.Length; i++){
                Label text = new Label();
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
                parent.Controls.Add(button);

                Button button2 = new Button();
                button2.Text = "-";
                button2.Parent = parent;
                button2.BackColor = Color.SkyBlue;
                button2.Location = new Point(startX + text.Width + button.Width + 10 , 25 + 40*i);
                button2.Size = new Size(20,20);
                parent.Controls.Add(button2);
            }
        }
        
    }

}