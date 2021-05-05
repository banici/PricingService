using PricingService.Models.Enums;
using PricingService.Models.Repo;
using System;


namespace PricingService.Models.BLL
{
    public class PricingServiceBLL : ServicePaymentPlan, IPricingServiceBLL
    {
        public int TotalDays(DateTime start, DateTime end)
        {
            return (int)(end - start.AddDays(-1)).TotalDays;
        }

        public int WeekDays(DateTime start, DateTime end)
        {
            var totalDays = TotalDays(start, end);
            var weekDayCounter = 0;

            for (int i = 1; i <= totalDays; i++)
            {
                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                {
                    weekDayCounter++;
                }

                start = start.AddDays(1);
            }

            return weekDayCounter;

        }

        public int WorkingServiceDay(DateTime start, DateTime end, PricingServiceType service)
        {
            if (service == PricingServiceType.C)
            {
                return TotalDays(start, end);
            }

            return WeekDays(start, end);
        }

        public override double PaymentPlan(Customer customer, PricingServiceType service)
        {
            switch (service)
            {
                case PricingServiceType.A:
                    // MemberDiscount = Discount.DiscountServiceA != null ? Discount.DiscountServiceA : 0;
                    return customer.MemberPriceServiceA > 0 ? customer.MemberPriceServiceA : base.ServiceA;

                case PricingServiceType.B:
                    //MemberDiscount = Discount.DiscountServiceB.Value;
                    return customer.MemberPriceServiceB > 0 ? customer.MemberPriceServiceB : base.ServiceB;

                case PricingServiceType.C:
                    //MemberDiscount = Discount.DiscountServiceC.Value;
                    return customer.MemberPriceServiceC > 0 ? customer.MemberPriceServiceC : base.ServiceC;

                default: throw new Exception("Service type input incorrect.");
            }

        }

    }
}
