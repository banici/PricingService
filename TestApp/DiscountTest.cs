using NUnit.Framework;
using PricingService.Models;
using PricingService.Models.Enums;
using PricingService.Models.Repo;
using System;

namespace TestApp
{

    public class DiscountTest
    {
        Customer customer = new Customer();

        [SetUp]
        public void Setup()
        {            
        }

        [Test]
        public void Test1()
        {
            // Arrange

           // var price = customer.PaymentPlan(PricingServiceType.A);


            // Act
            var sum = 0;
            
            // Assert

            Assert.AreEqual(50, sum);
        }

        //[Test]
        //public void Test2()
        //{
        //    // Arrange
        //    double price = customer.PaymentPlan(PricingServiceType.A);
        //    DateTime start = new DateTime(2021, 01, 01);
        //    DateTime end = new DateTime(2021, 01, 10);
        //    discount.DiscountServiceA = 0.5;

        //    // Act
        //    double sum = Discount.DiscountCalculator(price, start, end);

        //    // Assert

        //    Assert.AreEqual(50, sum);
        //}

        //[Test]
        //public void CustomerSpecialServicePrice_ReturnTrue(IPricingServiceBLL _ps)
        //{
        //    _ps = ps;
        //    // Arrange
        //    var currentPrice = customer.MemberPriceServiceA = 10;
        //    DateTime start = new DateTime(2021, 01, 01);
        //    DateTime end = new DateTime(2021, 01, 10);


        //    // Act
        //    double sum = currentPrice * _ps.WorkingServiceDay(start, end, PricingServiceType.A);

        //    // Assert

        //    Assert.AreEqual(50, sum);
        //}
    }
}
