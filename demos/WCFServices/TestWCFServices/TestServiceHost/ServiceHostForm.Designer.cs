namespace TestServiceHost {
  partial class ServiceHostForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.label1 = new System.Windows.Forms.Label();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 48);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(77, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Service closed";
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationsToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(211, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // operationsToolStripMenuItem
      // 
      this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openServiceToolStripMenuItem,
            this.closeSToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
      this.operationsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
      this.operationsToolStripMenuItem.Text = "Operations";
      // 
      // openServiceToolStripMenuItem
      // 
      this.openServiceToolStripMenuItem.Name = "openServiceToolStripMenuItem";
      this.openServiceToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.openServiceToolStripMenuItem.Text = "Open Service";
      this.openServiceToolStripMenuItem.Click += new System.EventHandler(this.openServiceToolStripMenuItem_Click);
      // 
      // closeSToolStripMenuItem
      // 
      this.closeSToolStripMenuItem.Name = "closeSToolStripMenuItem";
      this.closeSToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.closeSToolStripMenuItem.Text = "Close Service";
      this.closeSToolStripMenuItem.Click += new System.EventHandler(this.closeServiceToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // ServiceHostForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(211, 93);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.menuStrip1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MainMenuStrip = this.menuStrip1;
      this.MaximizeBox = false;
      this.Name = "ServiceHostForm";
      this.Text = "ServiceHost";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServiceHostForm_FormClosing);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openServiceToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeSToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
  }
}

