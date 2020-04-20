using MyShop.Data.Dto;
using MyShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop.Data.Converters
{
    public static class UserConverter
    {
        public static User Convert(UserDto item) =>
        new User
        {
            Email = item.Email,
            Id = item.Id,
            Name = item.Name,
            UserName = item.Email
           // ProductId = item.ProductId
        };

        public static UserDto Convert(User item) =>
        new UserDto
        {
            Email = item.Email,
            Id = item.Id,
            Name = item.Name
          //  ProductId = item.ProductId
        };

        public static List<User> Convert(List<UserDto> items) =>
        items.Select(a => Convert(a)).ToList();

        public static List<UserDto> Convert(List<User> items) =>
        items.Select(a => Convert(a)).ToList();
    }
}
