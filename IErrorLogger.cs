using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    interface IErrorLogger
    {
        void HandleException(Exception ex);
    }
}
