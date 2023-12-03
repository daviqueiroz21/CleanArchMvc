using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<T> RemoveAsync(T item);
    }
}
