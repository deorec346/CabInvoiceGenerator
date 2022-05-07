using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
   public class InvoiceException:Exception
    {
        public ExceptionType exception;
        public enum ExceptionType
        {
            INVALID_DISTANCE, INVALID_TIME,NO_RIDES_FOUND
        }
        public InvoiceException(ExceptionType exception, string message) : base(message)
        {
            this.exception = exception;
        }
    }
}
