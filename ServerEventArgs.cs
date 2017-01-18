using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace RemoteControl
{
    public class ServerEventArgs : EventArgs
    {
        public Image Image { get; set; }
        public Point CursorPosition { get; set; }
    }

}
