using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product> 
    {
        Task<Product> GetByIdAsync(int? id);

        Task<Product> GetProductCategoryAsync(int? id);
    }
}
