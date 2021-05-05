using Microsoft.AspNetCore.Mvc;
using PricingService.Models;
using PricingService.Models.Enums;
using PricingService.Models.Repo;
using System;

namespace PricingService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IPricingServiceBLL pricingService;
        
        public Discount Discount;

        Customer customer = new Customer
        {
            Id = 1,
            MemberPriceServiceA = 5,
            StartService = new DateTime(2021, 04, 01),
            EndService = new DateTime(2021, 04, 10),
        };

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
                    //startDate = customer.StartService, // remove later
                    //endDate = customer.EndService, // remove later
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

                var currentPrice = customer.PaymentPlan(service);

                customer.AccountBalance += currentPrice * pricingService.WorkingServiceDay(startDate, endDate, service);

                customer.AccountBalance -= currentPrice * customer.FreeDays;

                //customer.AccountBalance -= Discount.DiscountCalculator(currentPrice, Discount.StartDiscount, Discount.EndDiscount);



                return Ok(customer.AccountBalance);

                
            }


            return NotFound();


        }

    }

}
