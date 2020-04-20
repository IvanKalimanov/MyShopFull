using MyShop.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Data.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAll();

        Task<UserDto> GetByIdAsync(Guid id);

        Task<UserDto> GetByEmail(string email);

        Task<UserDto> Create(UserDto item);

        Task<bool> Update(UserDto item);

        Task<bool> Delete(Guid id);

        Task<bool> ChangePassword(string email, string oldPassword, string newPassword);

        //Task<bool> AddToBasket(string Email, Guid id);
    }
}
