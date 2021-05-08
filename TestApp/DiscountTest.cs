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
        public void FreeDaySubtraction()
        {
            // Arrange
            int accountBalance = 40;
            int rate = 13;
            int freeDays = 0;

            // Act
            while (freeDays > 0)
            {
                if (accountBalance <= 0)
                {
                    accountBalance = 0;
                    break;
                }

                accountBalance -= rate;
                freeDays--;
            }

            // Assert
            
            //Assert.AreEqual(freeDays, 5);
            Assert.AreEqual(accountBalance, 5);

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
