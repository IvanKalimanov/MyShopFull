using MyShop.AUTH.Models;
using MyShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.AUTH.Interfaces
{
    public interface IJwtGenerator
    {
        Task<Response<Token>> GenerateJwt(User user);
    }
}
