using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Data.Entities
{
    public class ChangeRole
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<IdentityRole<Guid>> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public ChangeRole()
        {
            AllRoles = new List<IdentityRole<Guid>>();
            UserRoles = new List<string>();
        }
    }
}
