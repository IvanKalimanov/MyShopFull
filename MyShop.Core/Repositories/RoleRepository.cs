using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole<Guid>> _rm;

        public RoleRepository(RoleManager<IdentityRole<Guid>> rm)
        {
            _rm = rm;
        }

        public async Task<List<IdentityRole<Guid>>> GetAll()
        {
            return await _rm.Roles.ToListAsync();
        }

        public async Task<IdentityRole<Guid>> GetByIdAsync(Guid id)
        {
            return await _rm.FindByIdAsync(id.ToString());
        }

        public async Task<IdentityRole<Guid>> GetByName(string name)
        {
            return await _rm.FindByNameAsync(name);
        }

        public async Task<bool> Delete(Guid id)
        {
            return (await _rm.DeleteAsync(
                await _rm.FindByIdAsync(id.ToString()))).Succeeded;
        }

        public async Task<IdentityRole<Guid>> Create(string name)
        {
            var result = await _rm.CreateAsync(new IdentityRole<Guid>(name));
            if (result.Succeeded)
                return await _rm.FindByNameAsync(name);
            return null;
        }

         public async Task<bool> DeleteByName(string name)
        {
            return (await _rm.DeleteAsync(await _rm.FindByNameAsync(name))).Succeeded;
        }
    }
}
