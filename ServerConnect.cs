using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RemoteControl
{


    class ServerConnect
    {
        public const string CommandImage = "RECIEVEIMAGE";
        public const string CommandCursor = "RECIEVECURSORPOSITION";
        public const string CommandStop = "STOP";
        public const string CommandKeyPressed = "KEY";
        public const string CommandMousePressed = "MOUSE";
        public const string CommandLeftMouseUP = "LFU";
        public const string CommandLeftMouseDOWN = "LFD";
        public const string CommandRightMouseUP = "RFU";
        public const string CommandShutdown = "CSD";
        public const string CommandRightMouseDOWN = "RFD";
        private const string CommandMiddleMouseUP = "MFU";
        private const string CommandMiddleMouseDOWN = "MFD";
      

        public static event EventHandler<ServerEventArgs> EventImageRecieved;

        public static TcpClient server;
        public static NetworkStream netStream;
        public static BinaryReader binaryReader;
        public static BinaryWriter binaryWriter;
        public static Boolean isOnline = false;
        public static Boolean sendMouseInput = true;
        private static BinaryFormatter binaryFormatter;

        public static Form parentForm;

        public static Task listeningTask;
        public static Task transmissionTask;
                
        public static void Connect(string ipAdress, int port)
        {
            SetupFields(new ServerErrorHandler("Error connecting to server"), ipAdress, port);
   
        }

        private static void SetupFields(IErrorLogger log, string ipAdress, int port)
        {
            if (server != null) server.Close();
            server = new TcpClient();
            try
            {
                server.Connect(ipAdress, port);
                netStream = server.GetStream();

                binaryReader = new BinaryReader(netStream, Encoding.UTF8);
                binaryWriter = new BinaryWriter(netStream, Encoding.UTF8);
                binaryFormatter = new BinaryFormatter();
                isOnline = true;
            }
            catch (Exception e)
            {
                log.HandleException(e);
            }
                          

        }

        public static void Listen()
        {
            
            listeningTask = new Task(() => RecieveTransmission());
            transmissionTask = new Task(() => SendTransmission());

            listeningTask.Start();
            transmissionTask.Start();
            listeningTask.Wait();
            transmissionTask.Wait();
           

            Disconnect(new ServerErrorHandler("Connection ending error."));

        } 

        public static void RecieveTransmission()
        {
            if (server != null)
            {
                while (isOnline)
                {
                    try
                    {
                        string message = binaryReader.ReadString();

                        switch (message)
                        {
                            case CommandImage:
                                RecieveImage();
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

        }

        public static void SendTransmission()
        {
            if (sendMouseInput == true)
            {
                Point startingPoint = new Point(0, 0);
                Point endingPoint = new Point(0, 0);
                Point deltaPoint = new Point(0, 0);
                while (isOnline)
                {
                    if (sendMouseInput == true)
                    {

                        try
                        {

                            deltaPoint.X = endingPoint.X - startingPoint.X;                                         // how to handle delta properly. AKA how to structure
                            deltaPoint.Y = endingPoint.Y - startingPoint.Y;

                            startingPoint.X = Cursor.Position.X;
                            startingPoint.Y = Cursor.Position.Y;

                            binaryWriter.Write(CommandCursor);
                            binaryWriter.Write(deltaPoint.X);
                            binaryWriter.Write(deltaPoint.Y);
                            binaryWriter.Flush();

                            Thread.Sleep(30);
                            endingPoint.X = Cursor.Position.X;
                            endingPoint.Y = Cursor.Position.Y;
                        }
                        catch (Exception ex)
                        {
                            isOnline = false;
                        }
                    }
                    else
                    {
                        // Do nothing.
                    }


                }
            }
            

        }

        public static void Disconnect(IErrorLogger log)
        {
            isOnline = false;
            try
            {
                binaryReader.Close();
                binaryWriter.Close();
                netStream.Close();
                server.Close();
                if (parentForm != null)
                {
                    parentForm.Invoke((MethodInvoker)delegate () { parentForm.Close(); });
                }

            }
            catch(Exception ex)
            {
                log.HandleException(ex);
            }

        }

        private static void RecieveImage()
        {
            Image screenshot = (Image)DesktopScreen.DeserializeScreen(netStream);
            OnEventImageRecieved(new ServerEventArgs() { Image = screenshot });
        }

       

        public static void OnEventImageRecieved(ServerEventArgs args)
        {
            if(EventImageRecieved != null)
            {
                EventImageRecieved(null, args);
            }
        }
    }
}
