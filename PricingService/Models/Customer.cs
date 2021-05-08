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


        //This method rounds up the balance to 0 once it reaches 0 or as soon it goes below 0.
        //Also subtract the amount of freedays stored in customer so it can save up leftover days in cases 
        public void FreeDaySubtraction(Customer customer, double rate)
        {
            while(customer.FreeDays > 0)
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
