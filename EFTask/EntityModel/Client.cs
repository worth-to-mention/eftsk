using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask.EntityModel
{
    
    public class Client
    {
        public Client()
        {
            Payments = new HashSet<Payment>();
        }

        public Guid ID { get; set; }

        public String Login { get; set; }

        public String FirstName { get; set; }

        public String SecondName { get; set; }

        public virtual ICollection<Payment> Payments { get; private set; }
    }
}
