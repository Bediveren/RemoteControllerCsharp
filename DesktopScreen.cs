using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace RemoteControl
{
    static class DesktopScreen
    {
        public static BinaryFormatter binaryFormatter;

        [Obsolete]
        public static Bitmap GetScreen()
        {
            
            Bitmap desktopScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics screen = Graphics.FromImage(desktopScreen);
            screen.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, desktopScreen.Size, CopyPixelOperation.SourceCopy);
            return desktopScreen;
        }

        public static void SerializeScreen(NetworkStream netStream, Bitmap image)
        {
            if (binaryFormatter == null) binaryFormatter = new BinaryFormatter();

            try
            {
                binaryFormatter.Serialize(netStream, image);
            }
            catch (Exception e)
            {
                throw new ArgumentNullException();
            }

        }

        public static object DeserializeScreen(NetworkStream netStream)
        {
            if (binaryFormatter == null) binaryFormatter = new BinaryFormatter();

            return binaryFormatter.Deserialize(netStream);
        }

        // STUDY THE CODE
        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll")]
        static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        const Int32 CURSOR_SHOWING = 0x00000001;

        public static Bitmap CaptureScreen(bool CaptureMouse)
        {
            Bitmap result = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb);

            try
            {
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

                    if (CaptureMouse)
                    {
                        CURSORINFO pci;
                        pci.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(CURSORINFO));

                        if (GetCursorInfo(out pci))
                        {
                            if (pci.flags == CURSOR_SHOWING)
                            {
                                DrawIcon(g.GetHdc(), pci.ptScreenPos.x, pci.ptScreenPos.y, pci.hCursor);
                                g.ReleaseHdc();
                            }
                        }
                    }
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

    }
}
