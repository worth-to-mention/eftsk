using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask.EntityModel
{
    public class PayPalPayment : Payment
    {
        public String Account { get; set; }
    }
}
