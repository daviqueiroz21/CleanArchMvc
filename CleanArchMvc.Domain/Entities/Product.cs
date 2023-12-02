using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public class Product
    {

        public int Id { get; set; }
        public int Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image {  get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
