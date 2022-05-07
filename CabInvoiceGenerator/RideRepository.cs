using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<int, InvoiceSummary> userSummary = new Dictionary<int, InvoiceSummary>();

        public void AddDetails(int id, Rides[] rides, RideType rideType)
        {
            try
            {
                //calculating the summary for each user
                InvoiceSummary summary = new InvoiceGenerator(rideType).CalcualateTotalFair(rides);
                //add the summary in dictionary
                userSummary.Add(id, summary);
            }
            catch (InvoiceException)
            {
                if (userSummary.ContainsKey(id))
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.USER_ID_ALREADY_AVAILABLE, "User id already available");
                }
                //checking whether the ride type is valid
                if (!(rideType.Equals(RideType.NORMAL) || rideType.Equals(RideType.PREMIUM)))
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.IVALID_RIDE_TYPE, "NO such type");
                }
            }
        }

        public InvoiceSummary ReadSummary(int id)
        {
            try
            {
                return userSummary[id];
            }
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_USERID, "No user available");
            }
        }
    }
}
