using MyShop.AUTH.Models;
using MyShop.Data.Dto;
using MyShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.AUTH.Interfaces
{
    public interface IAuthService
    {
        Task<Response<Token>> Login(string email, string password);

        Task<Response<string>> Register(UserDto item, string role);

        Task<Response<Token>> RefreshToken(string token, string refreshToken);

        Task SendConfirmation(User item);

        Task<Response<Token>> ConfirmEmail(string userId, string code);
    }
}
