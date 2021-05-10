using PricingService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricingService.Models.Dto
{
    public class DemostrationDto
    {
        public PricingServiceType PricingServiceType { get; set; }
        public Customer Customer { get; set; }
        public Discount Discount { get; set; }   
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
