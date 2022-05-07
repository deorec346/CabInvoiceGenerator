﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        //find the total fare for multiple ride
        [TestMethod]
        public void TotalFareForMultipleRides()
        {
            Rides[] rides = { new Rides(40, 10), new Rides(50, 25), new Rides(35, 5) };
            var actual = invoice.CalcualateTotalFair(rides);
            double expected = 1290;
            Assert.AreEqual(expected, actual);
        }
        //given the ride details return invoice summary
        [TestMethod]
        public void GivenMultipleRaidInvoiceSummaryTest()
        {
            Rides[] rides = { new Rides(40, 10), new Rides(50, 25), new Rides(35, 5) };
            InvoiceSummary actual = invoice.CalcualateTotalFair(rides);
            InvoiceSummary expected = new InvoiceSummary(3, 1290);
            var res = actual.Equals(expected);
            Assert.IsNotNull(res);
        }

    }
}
