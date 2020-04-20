using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Repositories
{
    public interface IRoleRepository
    {
        Task<List<IdentityRole<Guid>>> GetAll();

        Task<IdentityRole<Guid>> GetByIdAsync(Guid id);

        Task<IdentityRole<Guid>> GetByName(string name);

        Task<IdentityRole<Guid>> Create(string name);

        Task<bool> Delete(Guid id);

        Task<bool> DeleteByName(string name);
    }
}
