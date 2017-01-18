using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

using WindowsInput;

namespace RemoteControl
{

    static class ServerHost
    {
        public const string CommandImage = "RECIEVEIMAGE";
        public const string CommandCursor = "RECIEVECURSORPOSITION";
        public const string CommandStop = "STOP";
        public const string CommandKeyPressed = "KEY";
        public const string CommandMousePressed = "MOUSE";
        public const string CommandLeftMouseUP = "LFU";
        public const string CommandLeftMouseDOWN = "LFD";
        public const string CommandRightMouseUP = "RFU";
        public const string CommandRightMouseDOWN = "RFD";
        private const string CommandMiddleMouseUP = "MFU";
        private const string CommandMiddleMouseDOWN = "MFD";
        private const string CommandShutdown = "CSD";

        private static IPAddress serverIP;
        private static int serverPort;
        private static TcpListener server;
        private static TcpClient client;
        public static Boolean isOnline = false;

        private static Boolean connectionTerminated = true;
        private static BinaryWriter binaryWriter;
        private static BinaryReader binaryReader;
        private static BinaryFormatter binaryFormatter;
        private static NetworkStream netStream;

        private static Task listeningTask;
        private static Task transmissionTask;

        public static Form parentForm;
     
        public static event EventHandler<ServerEventArgs> EventCursorUpdate;

        public static void Start()
        {
            serverIP = IPAddress.Any;
            serverPort = 2000;
            server = new TcpListener(serverIP, serverPort);
            binaryFormatter = new BinaryFormatter();
            isOnline = true;
            connectionTerminated = false;
            server.Start();
        }

        
        public static void Stop(IErrorLogger log)
        {
           
            if (connectionTerminated == false)
            {
                try
                {
                    isOnline = false;
                    binaryWriter.Close();
                    binaryReader.Close();
                    netStream.Close();
                    client.Close();
                    server.Stop();
                    connectionTerminated = true;
                    if (parentForm != null)
                    {
                        parentForm.Invoke((MethodInvoker)delegate () { parentForm.Close(); });
                    }


                }
                catch (Exception ex)
                {
                    log.HandleException(ex);
                }
            }

        }


        public static void AcceptClient()
        {
            client = server.AcceptTcpClient();
            netStream = client.GetStream();
            binaryReader = new BinaryReader(netStream, Encoding.UTF8);
            binaryWriter = new BinaryWriter(netStream, Encoding.UTF8);
            EventCursorUpdate += NewCursorPosition;
        }

        public static void Listen()
        {
           
            Task acceptClientTask = new Task(() => AcceptClient());
            acceptClientTask.Start();
            acceptClientTask.Wait();

            listeningTask = new Task(() => RecieveTransmission());
            transmissionTask = new Task(() => SendTransmission());

            listeningTask.Start();
            transmissionTask.Start();
            listeningTask.Wait();
            transmissionTask.Wait();
            
            Stop(new ServerErrorHandler("Client disconnected."));
            
        }

        private static void RecieveTransmission()
        {
         
            while (isOnline)
            {
                try
                {
                    string message = binaryReader.ReadString();

                    switch (message)
                    {
                        case CommandCursor:
                            UpdateCursorPosition();
                            break;
                        case CommandMousePressed:
                            InputMouseClicked(binaryReader.ReadString());
                            break;
                        case CommandKeyPressed:
                            InputKeyPressed(binaryReader.ReadInt32());
                            break;
                        case CommandShutdown:
                            Process.Start("shutdown", "/s /t 0");
                            break;

                        default:

                            break;

                    }

                }
                catch (Exception ex)
                {
                    isOnline = false;
                }
            }
        }

        private static void NewCursorPosition(object source, ServerEventArgs args)
        {
            Cursor.Position = new Point(Cursor.Position.X + args.CursorPosition.X, Cursor.Position.Y + args.CursorPosition.Y);
        }

        private static void UpdateCursorPosition()
        {
            OnEventCursorUpdate(new ServerEventArgs() { CursorPosition = new Point(binaryReader.ReadInt32(), binaryReader.ReadInt32()) });

        }

        public static void OnEventCursorUpdate(ServerEventArgs args)
        {
            if (EventCursorUpdate != null)
            {
                EventCursorUpdate(null, args);
            }
        }
          
        public static void InputMouseClicked(string mouse)
        {          
            switch(mouse)
            {
                case CommandLeftMouseDOWN:
                    Mouse.mouse_event(Mouse.MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    break;

                case CommandRightMouseDOWN:
                    Mouse.mouse_event(Mouse.MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    break;
                case CommandMiddleMouseDOWN:
                    Mouse.mouse_event(Mouse.MOUSEEVENTF_MIDDLEDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    break;
                case CommandLeftMouseUP:
                    Mouse.mouse_event(Mouse.MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    break;
                case CommandRightMouseUP:
                    Mouse.mouse_event(Mouse.MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    break;
                case CommandMiddleMouseUP:
                    Mouse.mouse_event(Mouse.MOUSEEVENTF_MIDDLEUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    break;

                default:
                    break;

            }          
        }

        public static void InputKeyPressed(Int32 key)
        {
            VirtualKeyCode keyCode = (VirtualKeyCode) key;
            InputSimulator.SimulateKeyDown(keyCode);
        }

        private static void SendTransmission()
        {
            
            while (isOnline)
            {
                try
                {
                    binaryWriter.Write(CommandImage);
                    binaryWriter.Flush();
                    Bitmap screenshot = DesktopScreen.CaptureScreen(true);

                    DesktopScreen.SerializeScreen(netStream, screenshot);

                    netStream.Flush();
                }
                catch(Exception e)
                {
                    isOnline = false;
                    
                }

                Thread.Sleep(10);
            }
        }
    }
}
