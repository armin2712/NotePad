using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{

    /// <summary>
    /// Provides data for ErrorOcurred Evenet
    /// </summary>
    public class ErrorOccurredEventArgs:System.EventArgs
    {
        /// <summary>
        /// Calls the Exception object of the Error
        /// </summary>
        public System.Exception Exception { get; private set; }

        /// <summary>
        /// Initialized a new ErrorOccuredEventArgs Object
        /// </summary>
        /// <param name="exception">Exception object with the
        /// description of the Error</param>
        public ErrorOccurredEventArgs(System.Exception exception)
        {
            this.Exception = exception;        
        }
    }

    /// <summary>
    /// Provides the Method, that handles the ErrorOccured Event
    /// </summary>
    /// <param name="sender">Caller of the Method</param>
    /// <param name="e">Event data</param>
    public delegate void ErrorOccurredEventHandler(object sender, ErrorOccurredEventArgs e);
}
