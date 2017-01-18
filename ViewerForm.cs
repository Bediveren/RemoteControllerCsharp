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

using WindowsInput;

namespace RemoteControl
{
    public partial class ViewerForm : Form
    {
        private const string CommandLeftMouseUP = "LFU";
        private const string CommandLeftMouseDOWN = "LFD";
        private const string CommandRightMouseUP = "RFU";
        private const string CommandRightMouseDOWN = "RFD";
        private const string CommandMiddleMouseUP = "MFU";
        private const string CommandMiddleMouseDOWN = "MFD";

        Form parentForm;
        public ViewerForm(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;           
        }

        private void ViewerForm_Load(object sender, EventArgs e)
        {           
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ServerConnect.EventImageRecieved += ViewerForm_UpdatePicture;
            ServerConnect.parentForm = this;
            this.Capture = true;
            new Task(() => ServerConnect.Listen()).Start();


        }

        private void ViewerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Show();
        }

        public void ViewerForm_UpdatePicture(object source, ServerEventArgs args)
        {
            pictureBox.Image = args.Image;
        }

        private void ViewerForm_Shown(object sender, EventArgs e)
        {
        }

        private void ViewerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (ServerConnect.isOnline)
            {
                if (e.KeyCode == Keys.End)
                {
                    ServerConnect.binaryWriter.Write(ServerConnect.CommandShutdown);
                    ServerConnect.binaryWriter.Flush();
                }
                else if(e.KeyCode == Keys.Pause)
                {
                    if (ServerConnect.sendMouseInput == true) ServerConnect.sendMouseInput = false;
                    else ServerConnect.sendMouseInput = true;
                    
                }
                else
                {
                    ServerConnect.binaryWriter.Write(ServerConnect.CommandKeyPressed);
                    ServerConnect.binaryWriter.Write((Int32)e.KeyCode);
                    ServerConnect.binaryWriter.Flush();
                }
            }
        }

        private void CeaseConnection()
        {
            ServerConnect.isOnline = false;
            ServerConnect.Disconnect(new ServerErrorHandler("Could not cease connection. Please terminate it manually"));

        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (ServerConnect.isOnline)
            {
                ServerConnect.binaryWriter.Write(ServerConnect.CommandMousePressed);
                if (e.Button == MouseButtons.Left)
                {
                    ServerConnect.binaryWriter.Write(CommandLeftMouseUP);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    ServerConnect.binaryWriter.Write(CommandRightMouseUP);
                }
                else
                {
                    ServerConnect.binaryWriter.Write(CommandMiddleMouseUP);
                }
                ServerConnect.binaryWriter.Flush();
            }

        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (ServerConnect.isOnline)
            {
                ServerConnect.binaryWriter.Write(ServerConnect.CommandMousePressed);
                if (e.Button == MouseButtons.Left)
                {
                    ServerConnect.binaryWriter.Write(CommandLeftMouseDOWN);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    ServerConnect.binaryWriter.Write(CommandRightMouseDOWN);
                }
                else
                {
                    ServerConnect.binaryWriter.Write(CommandMiddleMouseDOWN);
                }
                ServerConnect.binaryWriter.Flush();
            }
        }
    }
}
