using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CabInvoiceGenerator;


namespace InvoiceGeneratorTest
{
    [TestClass]
    public class UnitTest1
    {
        InvoiceGenerator invoice;

        [TestInitialize]
        public void setup()
        {
            invoice = new InvoiceGenerator();
        }
        //method to find the total fare of single ride
        [TestMethod]
        public void TotalFareForSingleRide()
        {
            double distance = 40;
            double time = 10;
            double actual = invoice.CalculateFare(distance, time);
            double expected = 410;
            Assert.AreEqual(expected, actual);
        }
        //find the total fare of single ride with distance as Zero
        [TestMethod]
        public void TotalFareForSingleRideWithDistanceZeroTest()
        {
            try
            {
                double distance = 0;
                double time = 10;
                var actual = invoice.CalculateFare(distance, time);
            }
            catch (InvoiceException IE)
            {
                Assert.AreEqual("Distance Cannot be 0", IE.Message);
            }
        }
        //find the total fare of single ride with Time as Zero
        [TestMethod]
        public void TotalFareForSingleRideWithTimeZeroTest()
        {
            try
            {
                double distance = 40;
                double time = 0;
                var actual = invoice.CalculateFare(distance, time);
            }
            catch (InvoiceException IE)
            {
                Assert.AreEqual("Time Cannot be 0", IE.Message);
            }
        }
    }
}
