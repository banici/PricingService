using PricingService.Models.Enums;
using System;

namespace PricingService.Models.Repo
{
    public interface IPricingServiceBLL
    {
        int TotalDays(DateTime start, DateTime end);
        int WeekDays(DateTime start, DateTime end);
        int WorkingServiceDay(DateTime start, DateTime end, PricingServiceType service);
        double PaymentPlan(Customer customer, PricingServiceType service);

    }
}
