using PricingService.Models.Enums;
using System;

namespace PricingService.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public DateTime StartDiscount { get; set; }
        public DateTime EndDiscount { get; set; }
        public double? DiscountServiceA { get; set; }
        public double? DiscountServiceB { get; set; }
        public double? DiscountServiceC { get; set; }
        public int CustomerId { get; set; }

        public double DiscountCalculator(Customer customer, double rate /*double rate, DateTime start, DateTime end*/)
        {
            if(customer.Id == CustomerId)
            {
                customer.MemberDiscount = DiscountServiceA;

                var discount = customer.MemberDiscount;

                if (discount > 0)
                {
                    int discountPeriod = (int)(EndDiscount - StartDiscount.AddDays(-1)).TotalDays;

                    return (rate * discountPeriod) * discount.Value;
                }
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
