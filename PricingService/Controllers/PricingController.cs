﻿using Microsoft.AspNetCore.Mvc;
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

        Discount discount = new Discount
        {
            CustomerId = 1,
            DiscountServiceA = 0.5,
            StartDiscount = new DateTime(2021,02,01),
            EndDiscount = new DateTime(2021,02,10)
        };

        Customer customer = new Customer
        {
            Id = 1,
            FreeDays = 5,
            MemberPriceServiceA = 10,
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


                if (customer.Id == discount.CustomerId)
                {                    
                    customer.AccountBalance -= discount.DiscountCalculator(customer, currentPrice, service);
                }
                else if(customer.FreeDays > 0)
                {
                    customer.FreeDaySubtraction(customer, currentPrice);
                }


                return Ok(customer.AccountBalance);
                
            }


            return NotFound();


        }

    }

}
