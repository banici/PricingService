using PricingService.Models.Enums;
using System;

namespace PricingService.Models.BLL
{
    public abstract class ServicePaymentPlan
    {
        protected virtual double ServiceA { get { return 0.2; } }
        protected virtual double ServiceB { get { return 0.4; } }
        protected virtual double ServiceC { get { return 0.5; } }
        public virtual double PaymentPlan(PricingServiceType service)
        {
            switch (service)
            {
                case PricingServiceType.A:
                    return ServiceA;

                case PricingServiceType.B:
                    return ServiceB;

                case PricingServiceType.C:
                    return ServiceC;

                default: throw new Exception("Service type input incorrect.");
            }

        }
    }
}
