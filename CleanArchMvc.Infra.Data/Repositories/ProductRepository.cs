using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {

            _context = context;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.Products.Include(c => c.Category).SingleOrDefaultAsync(x => x.Id == id);

        }
    }
}
