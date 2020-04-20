using Microsoft.AspNetCore.Identity;
using MyShop.Data.Entities;
using MyShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Repositories
{
    public class ChangeRoleRepository : IChangeRoleRepository
    {
        private readonly RoleManager<IdentityRole<Guid>> _rm;
        private readonly UserManager<User> _um;

        public ChangeRoleRepository(RoleManager<IdentityRole<Guid>> rm, UserManager<User> um)
        {
            _rm = rm;
            _um = um;
        }

        public async Task<ChangeRole> GetUsersRoles(string id)
        {
            User user = await _um.FindByIdAsync(id);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _um.GetRolesAsync(user);
                var allRoles = _rm.Roles.ToList();
                ChangeRole model = new ChangeRole
                {
                    UserId = user.Id.ToString(),
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return model;
            }
            return null;
        }


        public async Task<bool> EditRolesOfUser(Guid userId, List<string> roles)
        {
            // получаем пользователя
            User user = await _um.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _um.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _rm.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _um.AddToRolesAsync(user, addedRoles);

                await _um.RemoveFromRolesAsync(user, removedRoles);

                return true;
            }

            return false;
        }
    }
}
