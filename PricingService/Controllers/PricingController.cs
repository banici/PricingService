using Microsoft.AspNetCore.Mvc;
using PricingService.Models;
using PricingService.Models.Enums;
using PricingService.Models.Repo;
using System;
using System.Collections.Generic;

namespace PricingService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IPricingServiceBLL pricingService;

        private readonly Discount discount;
        private readonly Customer customer;
        public PricingController(IPricingServiceBLL _pricingService)
        {
            pricingService = _pricingService;
        }


        [Route("ServiceTypeA/{customerId:int}/{start:datetime}/{end:datetime}")]
        public IActionResult ServiceTypeA(int customerId, DateTime start, DateTime end)
        {

            return RedirectToAction(
                "ServiceManager",
                new
                {
                    Id = customerId,
                    startDate = start,
                    endDate = end,
                    service = PricingServiceType.A
                });

        }

        [Route("ServiceTypeB/{customerId:int}/{start:datetime}/{end:datetime}")]
        public IActionResult ServiceTypeB(int customerId, DateTime start, DateTime end)
        {

            return RedirectToAction(
                "ServiceManager",
                new
                {
                    Id = customerId,
                    startDate = start,
                    endDate = end,
                    service = PricingServiceType.B
                });

        }

        [Route("ServiceTypeC/{customerId:int}/{start:datetime}/{end:datetime}")]
        public IActionResult ServiceTypeC(int customerId, DateTime start, DateTime end)
        {

            return RedirectToAction(
                "ServiceManager",
                new
                {
                    Id = customerId,
                    startDate = start,
                    endDate = end,
                    service = PricingServiceType.C
                });

        }

        [Route("ServiceManager")]
        public IActionResult ServiceManager(int? Id, DateTime startDate, DateTime endDate, PricingServiceType service)
        {

            if (Id != null || customer.Id != Id)
            {
                
                var currentPrice = pricingService.PaymentPlan(customer, service);

                customer.AccountBalance += currentPrice * pricingService.WorkingServiceDay(startDate, endDate, service);
                
                if (discount.CustomerId == customer.Id)
                {                    
                    customer.AccountBalance -= discount.DiscountCalculator(customer, currentPrice, service);
                }
                if(customer.FreeDays > 0)
                {
                    customer.FreeDaySubtraction(customer, currentPrice);
                }


                return Ok(customer.AccountBalance);
                
            }


            return NotFound();


        }

    }

}
