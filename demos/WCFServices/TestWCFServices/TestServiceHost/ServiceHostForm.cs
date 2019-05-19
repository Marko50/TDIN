using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace TestServiceHost {
  public partial class ServiceHostForm : Form {
    private ServiceHost SHost = null;

    public ServiceHostForm() {
      InitializeComponent();
    }

    private void openServiceToolStripMenuItem_Click(object sender, EventArgs e) {
      if (SHost == null) {
        SHost = new ServiceHost(typeof(StockService));
        SHost.Open();
        label1.Text = "Service open for business";
      }
    }

    private void closeServiceToolStripMenuItem_Click(object sender, EventArgs e) {
      if (SHost != null) {
        SHost.Close();
        SHost = null;
        label1.Text = "Service closed";
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
      Close();
    }

    private void ServiceHostForm_FormClosing(object sender, FormClosingEventArgs e) {
      if (SHost != null)
        SHost.Close();
    }
  }
}
