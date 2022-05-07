using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
   public class InvoiceGenerator
    {

        private readonly int COST_PER_KM;
        private readonly int COST_PER_MIN;
        private readonly int MIN_FARE;

        //initialize the readonly value through constructor
        public InvoiceGenerator()
        {
            this.COST_PER_KM = 10;
            this.COST_PER_MIN = 1;
            this.MIN_FARE = 5;
        }

        public double CalculateFare(double distance, double timeInMin)
        {
            //initialize the total fare
            double totalFare = 0;
            try
            {
                //calculate the total fare
                totalFare = distance * COST_PER_KM + timeInMin * COST_PER_MIN;
            }
            //throws exception if distance or time is zero
            catch (InvoiceException)
            {
                if (distance <= 0)
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_DISTANCE, "Distance Cannot be 0");
                if (timeInMin <= 0)
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_TIME, "Time cannot be 0");
            }
            return Math.Max(MIN_FARE, totalFare);
        }
        //passing the ride object as array
        //calculate total fair of each rides
        public double CalcualateTotalFair(Rides[] rides)
        {
            double totalFare = 0;
            try
            {
                //looping and finding the fair for each ride
                foreach (Rides r in rides)
                {
                    totalFare += CalculateFare(r.distance, r.time);
                }
            }
            //if null object is passed
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.NO_RIDES_FOUND, "No ride available");
            }
            return totalFare;
        }
    }
}
