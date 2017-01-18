using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteControl
{
    class FormErrorHandler : IErrorLogger 
    {
        string message; 
        public FormErrorHandler(string message)
        {
            this.message = message;    
        }
        public void HandleException(Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }
    }
}
