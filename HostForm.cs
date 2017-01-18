using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteControl
{
    public partial class HostForm : Form
    {
        Form parentForm;
        public HostForm(Form parentForm)
        {
            this.parentForm = parentForm;
            
            InitializeComponent();
        }

        private void HostForm_Load(object sender, EventArgs e)
        { 
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2, 0);
            ServerHost.parentForm = this;
            ServerHost.Start();
            
            new Task(() => ServerHost.Listen()).Start();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            //ServerHost.Stop(new ServerErrorHandler("Server termination unsuccessful"));
            this.Close();
        }


        private void HostForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CeaseConnection("Host transmission terminate");
            parentForm.Show();
        }

        public void UpdateButtonText(string text)
        {
            btnDisconnect.Text = text;
        }

        private void CeaseConnection(string message)
        {
            ServerHost.isOnline = false;
            ServerHost.Stop(new ServerErrorHandler(message));
        }

        private void HostForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
