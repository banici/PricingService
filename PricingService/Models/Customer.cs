using PricingService.Models.BLL;
using PricingService.Models.Enums;
using System;


namespace PricingService.Models
{
    public class Customer : ServicePaymentPlan
    {
        public Customer()
        {
            Discount discount = new Discount();
        }
        public int Id { get; set; }
        public int FreeDays { get; set; }
        public double MemberPriceServiceA { get; set; }
        public double MemberPriceServiceB { get; set; }
        public double MemberPriceServiceC { get; set; }
        public DateTime StartService { get; set; }
        public DateTime EndService { get; set; }
        public Discount Discount { get; set; }
        public double? MemberDiscount { get; set; }

        private double accountBalance;
        public double AccountBalance
        {
            get
            {
                return accountBalance;
            }
            set
            {
                accountBalance = Math.Round(value, 2);
            }
        }


        //public override double PaymentPlan(PricingServiceType service)
        //{
        //    switch (service)
        //    {
        //        case PricingServiceType.A:
        //                  // MemberDiscount = Discount.DiscountServiceA != null ? Discount.DiscountServiceA : 0;
        //            return MemberPriceServiceA > 0 ? MemberPriceServiceA : base.ServiceA;

        //        case PricingServiceType.B:
        //                   //MemberDiscount = Discount.DiscountServiceB.Value;
        //            return MemberPriceServiceB > 0 ? MemberPriceServiceB : base.ServiceB;

        //        case PricingServiceType.C:
        //                   //MemberDiscount = Discount.DiscountServiceC.Value;
        //            return MemberPriceServiceC > 0 ? MemberPriceServiceC : base.ServiceC;

        //        default: throw new Exception("Service type input incorrect.");
        //    }

        //}

    }
}
