using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

using WindowsInput;

namespace RemoteControl
{
    static class InputHandler
    {
        public static BinaryFormatter bf = new BinaryFormatter();
        private static StringBuilder inputString = new StringBuilder();
        public static string GetInputAsAString()
        {
            //This isn't even used... so much for refactoring. Leaving just bcuz...
            //string inputString = "";
            inputString.Clear();

            foreach (var keyCode in Enum.GetValues(typeof(VirtualKeyCode)).Cast<VirtualKeyCode>())
            {
                if(InputSimulator.IsKeyDown(keyCode))
                    inputString.Append(FormatString(keyCode.ToString()));
            }
            
            return inputString.ToString();
        } 

        private static string FormatString(string text)
        {
            return text + "\n";                                                
        }

    }
}
