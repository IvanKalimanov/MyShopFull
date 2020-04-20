using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.AUTH.Interfaces;
using MyShop.AUTH.Models;
using MyShop.Data.Dto;
using MyShop1.Models;
using MyShop1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop1.Controllers
{
    [Route("api/[action]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _auth;


        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost]
        [Produces(typeof(Response<Token>))]
        public async Task<ActionResult<Response<Token>>> Login([FromBody] LoginViewModel form)
        {
            try
            {
                var result = await _auth.Login(form.Email, form.Password);
                return StatusCode(result.Code, new Ack<Token>(result));
            }
            catch (Exception)
            {
                return StatusCode(520, new Ack<Token>(null, "Unknown error"));
            }
        }

        
        [HttpPost("{role}")]
        [Produces(typeof(Response<string>))]
        public async Task<ActionResult<Response<string>>> Register([FromBody] UserDto item, string role)
        {
            try
            {
                var result = await _auth.Register(item, role);
                return StatusCode(result.Code, new Ack<string>(result));
            }
            catch (Exception)
            {
                return StatusCode(520, new Ack<string>(null, "Unknown error"));
            }
        }
       
        [HttpPost]
        [Produces(typeof(Response<Token>))]
        public async Task<ActionResult<Response<Token>>> ConfirmEmail([FromBody]ConfirmationEmailViewModel model)
        {
            try
            {
                var result = await _auth.ConfirmEmail(model.UserId, model.Token);
                return StatusCode(result.Code, new Ack<Token>(result));
            }
            catch (Exception)
            {
                return StatusCode(520, new Ack<Token>(null, "Unknown error"));
            }
        }

        [HttpPost]
        [Produces(typeof(Response<Token>))]
        public async Task<ActionResult<Response<Token>>> RefreshToken([FromBody] RefreshViewModel item)
        {
            try
            {
                var result = await _auth.RefreshToken(item.AccessToken, item.RefreshToken);
                return StatusCode(result.Code, new Ack<Token>(result));
            }
            catch (Exception)
            {
                return StatusCode(520, new Ack<Token>(null, "Unknown error"));
            }
        }

        [HttpGet]
        [Authorize]
        [Produces(typeof(bool))]
        public ActionResult<bool> Test()
        {
            return true;
        }
    }
}
