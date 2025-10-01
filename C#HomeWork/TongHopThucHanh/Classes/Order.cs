using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TongHopThucHanh.Classes
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public List<Item> Items { get; set; }
        public Payment Payment { get; set; }
        public string ShippingMethod { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public BillingAddress BillingAddress { get; set; }
    }

}
