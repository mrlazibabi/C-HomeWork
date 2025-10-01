using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TongHopThucHanh.Classes
{
    public class Payment
    {
        public string PaymentMethod { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

}
