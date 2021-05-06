using PricingService.Models.BLL;
using PricingService.Models.Enums;
using System;


namespace PricingService.Models
{
    public class Customer// : ServicePaymentPlan
    {
        public int Id { get; set; }
        public int FreeDays { get; set; }
        public double MemberPriceServiceA { get; set; }
        public double MemberPriceServiceB { get; set; }
        public double MemberPriceServiceC { get; set; }
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

        public void FreeDaySubtraction(Customer customer, double rate)
        {
            for(int i = 0; i < customer.FreeDays; i++)
            {
                if(customer.AccountBalance <= 0)
                {
                    customer.AccountBalance = 0;
                    break;
                }

                customer.AccountBalance -= rate;
                customer.FreeDays--;
            }
        }
    }
}
