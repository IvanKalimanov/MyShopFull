using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public List<string> Messages { get; set; } = new List<string>();

        //public List<Guid> ProductId { get; set; } = new List<Guid>();
    }
}
