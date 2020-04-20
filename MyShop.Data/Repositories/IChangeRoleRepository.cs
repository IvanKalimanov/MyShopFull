using MyShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Repositories
{
    public interface IChangeRoleRepository
    {
        Task<ChangeRole> GetUsersRoles(string id);

        Task<bool> EditRolesOfUser(Guid id, List<string> roles);
    }
}
