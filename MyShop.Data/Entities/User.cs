using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }

        //public List<Guid> ProductId { get; set; } = new List<Guid>();
    }
}
