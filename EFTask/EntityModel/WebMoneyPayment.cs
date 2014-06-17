using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask.EntityModel
{
    public class WebMoneyPayment : Payment
    {
        public String EWAlletNumber { get; set; }
    }
}
