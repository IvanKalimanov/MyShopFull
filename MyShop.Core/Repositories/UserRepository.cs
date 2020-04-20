using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyShop.Data.Converters;
using MyShop.Data.Dto;
using MyShop.Data.Entities;
using MyShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _um;

        public UserRepository(UserManager<User> um)
        {
            _um = um;
        }

        public async Task<List<UserDto>> GetAll()
        {
            return UserConverter.Convert(await _um.Users.ToListAsync());
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            return UserConverter.Convert(await _um.FindByIdAsync(id.ToString()));
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            return UserConverter.Convert(await _um.FindByEmailAsync(email));
        }

        public async Task<UserDto> Create(UserDto user)
        {
            var result = await _um.CreateAsync(UserConverter.Convert(user));
            if (result.Succeeded)
            {
                return UserConverter.Convert(await _um.FindByEmailAsync(user.Email));
            }
            return null;
        }

        //public async Task<bool> AddToBasket(string email, Guid id)
        //{
        //    UserDto user = await GetByEmail(email);
        //    if (user != null)
        //    {
        //        user.ProductId.Add(id);
        //        return true;
        //    }
        //    return false;
        //}
        public async Task<bool> Update(UserDto user)
        {
            return (await _um.UpdateAsync(UserConverter.Convert(user))).Succeeded;
        }

        public async Task<bool> Delete(Guid id)
        {
            return (await _um.DeleteAsync(
                await _um.FindByIdAsync(id.ToString()))).Succeeded;
        }

        public async Task<bool> ChangePassword(string email, string oldPassword, string newPassword)
        {
            User user = await _um.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _um.ChangePasswordAsync(user, oldPassword, newPassword);
                if (result.Succeeded)
                    return true;
            }
            return false;

        }
    }
}
