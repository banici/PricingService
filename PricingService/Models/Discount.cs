using PricingService.Models.Enums;
using System;

namespace PricingService.Models
{
    public class Discount
    {
        public DateTime StartDiscount { get; set; }
        public DateTime EndDiscount { get; set; }
        public double? DiscountServiceA { get; set; }
        public double? DiscountServiceB { get; set; }
        public double? DiscountServiceC { get; set; }
        static Customer Customer { get; set; }

        public static double DiscountCalculator(double rate, DateTime start, DateTime end)
        {

            var discount = Customer.MemberDiscount;

            if (discount > 0)
            {
                int discountPeriod = (int)(end - start.AddDays(-1)).TotalDays;

                return (rate * discountPeriod) * discount.Value;
            }

            return 0;

        }

        //public double ServiceDiscount(PricingServiceType service)
        //{
        //    switch (service)
        //    {
        //        case PricingServiceType.A:
        //            return DiscountServiceA;

        //        case PricingServiceType.B:
        //            return DiscountServiceB;

        //        case PricingServiceType.C:
        //            return DiscountServiceC;

        //        default: throw new Exception("Service type input incorrect.");
        //    }

        //}
    }
}
