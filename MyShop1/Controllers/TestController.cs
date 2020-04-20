using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop1.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        [Authorize]
        public bool Auth()
        {
            return true;
        }

        [Authorize(Roles = "user")]
        public bool UserTest()
        {
            return true;
        }

        [Authorize(Roles = "admin")]
        public bool AdminTest()
        {
            return true;
        }
    }
}
