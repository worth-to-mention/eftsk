using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask.EntityModel
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment()
        {
            ValidityPeriod = new ValidityPeriod();
        }

        public String CardNumber { get; set; }

        public ValidityPeriod ValidityPeriod { get; set; }

        [NotMapped]
        public Int32 CVC { get; set; }
    }
}
