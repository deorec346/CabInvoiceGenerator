using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    class RideRepository
    {
        Dictionary<int, InvoiceSummary> userSummary = new Dictionary<int, InvoiceSummary>();

        public void AddDetails(int id, Rides[] rides)
        {
            try
            {
                //calculating the summary for each user
                InvoiceSummary summary = new InvoiceGenerator().CalcualateTotalFair(rides);
                //add the summary in dictionary
                userSummary.Add(id, summary);
            }
            catch (InvoiceException)
            {
                if (userSummary.ContainsKey(id))
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.USER_ID_ALREADY_AVAILABLE, "User id already available");
                }
            }
        }

        public InvoiceSummary ReadSummary(int id)
        {
            return userSummary[id];
        }
    }
}
