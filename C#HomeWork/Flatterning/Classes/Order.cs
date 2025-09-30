using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatterning.Classes
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public Customer Customer { get; set; }
    }
}
