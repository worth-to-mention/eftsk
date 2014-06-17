using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask.EntityModel
{
    public class Payment
    {
        public Guid ID { get; set; }

        public Int32 Quantity { get; set; }

        public DateTime Date { get; set; }

        public virtual Good Good { get; set; }
        
        public virtual Client Client { get; set; }
    }
}
