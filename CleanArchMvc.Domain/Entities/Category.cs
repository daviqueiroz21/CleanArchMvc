using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public ICollection<Product> Products{ get; set;}
    }
}
