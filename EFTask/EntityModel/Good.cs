using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask.EntityModel
{
    public class Good
    {
        public Good()
        {
            Categories = new HashSet<Category>();
            Payments = new HashSet<Payment>();
        }

        public Guid ID { get; set; }

        public String Name { get; set; }

        public Decimal Amount { get; set; }

        public virtual ICollection<Category> Categories { get; private set; }

        public virtual ICollection<Payment> Payments { get; private set; }
    }
}
