using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperInheritance.Models
{
    public abstract class OrderDto
    {
        public string TrackingInfo { get; set; }
    }

    public class OnlineOrderDto : OrderDto
    {
        public string BrowserVersion { get; set; }
    }

    public class MailOrderDto : OrderDto
    {
        public int DelivaryAgencyId { get; set; }
    }
}
