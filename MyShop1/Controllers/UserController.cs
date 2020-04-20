using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.Data.Dto;
using MyShop.Data.Entities;
using MyShop.Data.Repositories;
using MyShop1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop1.Controllers
{
    [Route("api/{controller}")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
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

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(Guid id)
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

        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserDto>> Get(string email)
        {
            try
            {
                return await _repo.GetByEmail(email);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody]UserDto item)
        {
            try
            {
                return await _repo.Create(item);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        //[HttpPost]
        //public async Task<ActionResult<bool>> Post([FromBody]AddToBasketViewModel model)
        //{
        //    try
        //    {
        //        return await _repo.AddToBasket(model.Email, model.ProductId);
        //    }
        //    catch(Exception e)
        //    {
        //        return StatusCode(500, e);
        //    }
        //}
        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody]UserDto user)
        {
            try
            {
                return await _repo.Update(user);
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

        
        [HttpPost("changepassword")]
        [Authorize]
        public async Task<ActionResult<bool>> Post([FromBody] ChangePasswordViewModel model)
        {
            try
            {
                return await _repo.ChangePassword(model.Email, model.OldPassword, model.NewPassword);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
