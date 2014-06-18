using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask.EntityModel
{
    public class Category
    {
        public Category()
        {
            Children = new HashSet<Category>();
            Goods = new HashSet<Good>();
        }

        public Guid ID { get; set; }

        public String Name { get; set; }

        public Guid? Parent_Id { get; set; }

        public virtual ICollection<Category> Children { get; private set; }

        public virtual ICollection<Good> Goods { get; private set; }

        public virtual Category Parent { get; set; }
    }
}
