using Microsoft.AspNetCore.Mvc;
using MyShop.Data.Entities;
using MyShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop1.Controllers
{
    [Route("api/{controller}")]
    public class ChangeRoleController : Controller
    {
        private readonly IChangeRoleRepository _repo;

        public ChangeRoleController(IChangeRoleRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChangeRole>> Get(string id)
        {
            try
            {
                return await _repo.GetUsersRoles(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        public class Roles
        {
            public List<string> roles { get; set; }
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<bool>> Post(Guid id, [FromBody]Roles roles)
        {
            try
            {
                return await _repo.EditRolesOfUser(id, roles.roles);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
