using MyShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(Guid id);

        Task<List<Product>> GetByListIdAsync(List<Guid> id);

        Task<List<Product>> GetByCategoryAsync(Guid id);

        Task<bool> AddComment(Comments comment);

        Task<Product> CreateAsync(Product item);

        Task<bool> UpdateAsync(Product item);

        Task<bool> DeleteAsync(Guid id);
    }
}
