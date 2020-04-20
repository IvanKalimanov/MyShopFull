using MyShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Repositories
{
    public interface ICommentsRepository
    {
        Task<List<Comments>> GetAllAsync();

        Task<List<Comments>> GetByProductIdAsync(Guid id);

        Task<bool> DeleteAsync(Guid id);
    }

}