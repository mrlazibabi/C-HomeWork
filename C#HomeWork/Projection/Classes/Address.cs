using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection.Classes
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public Country Country { get; set; }
    }
}
