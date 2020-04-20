using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop1.Controllers
{
    [Route("api/{controller}")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _repo;

        public RoleController(IRoleRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityRole<Guid>>> Get(Guid id)
        {
            try
            {
                return await _repo.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IdentityRole<Guid>>> Get([FromBody]string name)
        {
            try
            {
                return await _repo.GetByName(name);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<IdentityRole<Guid>>>> Get()
        {
            try
            {
                return await _repo.GetAll();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        [HttpPost]
        public async Task<ActionResult<IdentityRole<Guid>>> Post([FromBody]string name)
        {
            try
            {
                return await _repo.Create(name);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            try
            {
                return await _repo.Delete(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        public async Task<ActionResult<bool>> Delete([FromBody]string name)
        {
            try
            {
                return await _repo.DeleteByName(name);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}
