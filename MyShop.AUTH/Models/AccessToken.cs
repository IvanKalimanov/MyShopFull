using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.AUTH.Models
{
    public class AccessToken
    {
        public string Token { get; set; }

        public long ExpiresIn { get; set; }
    }
}
