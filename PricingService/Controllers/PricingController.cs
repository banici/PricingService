using Microsoft.AspNetCore.Mvc;
using PricingService.Models;
using PricingService.Models.Dto;
using PricingService.Models.Enums;
using PricingService.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PricingService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IPricingServiceBLL pricingService;
        public PricingController(IPricingServiceBLL _pricingService)
        {
            pricingService = _pricingService;
        }



        static List<Discount> discountList = new List<Discount>();  // For demo purpose instead of db context
        static Discount discount = new Discount();                  // For demo purpose instead of db context
        static List<Customer> customerList = new List<Customer>();  // For demo purpose instead of db context
        static Customer customer = new Customer();                  // For demo purpose instead of db context
        
        // This postmethod executes a demostration of this program when using it on Postman
        // it should be replaced with a database instead for the purpose of this program. But for now it shows only a Demo.
        [Route("PostDemo")]
        public IActionResult PostDemo(DemostrationDto dt)
        {

            customerList.Add(dt.Customer); 

            dt.Discount.CustomerId = dt.Customer.Id;
            discountList.Add(dt.Discount);

            return RedirectToAction(
                "ServiceManager",
                new
                {
                    Id = dt.Customer.Id,
                    startDate = dt.Start,
                    endDate = dt.End,
                    service = dt.PricingServiceType
                });
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
            customer = customerList.Where(c => c.Id == Id).FirstOrDefault();
            discount = discountList.Where(d => d.CustomerId == customer.Id).FirstOrDefault();

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
