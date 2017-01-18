using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
     
namespace RemoteControl
{
    public partial class SetupForm : Form
    {
        public SetupForm()
        {
            InitializeComponent();    
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ServerConnect.Connect(tbIPAdress.Text, Int32.Parse(tbPort.Text));
            
            if (ServerConnect.netStream != null)
            {
                this.Hide();
                new ViewerForm(this).ShowDialog();
            }
        }

        private void btnHost_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            new HostForm(this).ShowDialog();
        }
    }
}
