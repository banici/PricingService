using Microsoft.AspNetCore.Mvc;
using PricingService.Models;
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
        private readonly Discount discount;
        List<Customer> customerList = new List<Customer>();
        Customer customer = new Customer();
        public PricingController(IPricingServiceBLL _pricingService)
        {
            pricingService = _pricingService;
        }

        [Route("PostCustomer")]
        public IActionResult PostCustomerAndDiscountForTesting(Customer _customer)
        {
            Customer kustomer = new Customer();
            kustomer.Id = _customer.Id;
            kustomer.FreeDays = _customer.FreeDays;
            kustomer.MemberPriceServiceA = _customer.MemberPriceServiceA;
            kustomer.MemberPriceServiceB = _customer.MemberPriceServiceB;
            kustomer.MemberPriceServiceC = _customer.MemberPriceServiceC;

            customerList.Add(kustomer);

            return RedirectToAction(
                "ServiceManager",
                new
                {
                    Id = customer.Id,
                    startDate = new DateTime(2021, 02, 01),
                    endDate = new DateTime(2021, 02, 10),
                    service = PricingServiceType.A
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
            customer = customerList.Where(x => x.Id == Id).FirstOrDefault();
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
