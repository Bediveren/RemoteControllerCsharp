using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace RemoteControl
{
    class Mouse
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public static int MOUSEEVENTF_LEFTDOWN = 0x02;
        public static int MOUSEEVENTF_LEFTUP = 0x04;
        public static int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public static int MOUSEEVENTF_RIGHTUP = 0x0010;
        public static int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        public static int MOUSEEVENTF_MIDDLEUP = 0x40;
    }
}
