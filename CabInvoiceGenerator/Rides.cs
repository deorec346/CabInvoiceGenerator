using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class Rides
    {

        public double distance;
        public int time;
        public Rides(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
