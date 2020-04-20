using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyShop.Core.Hubs;
using MyShop.Core.Hubs.Models;
using MyShop.Data.Entities;
using MyShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyShop1.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ChatController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IHubContext<AuthChatHub> _authHubContext;
        private readonly IProductRepository _repo;

        public ChatController(IHubContext<ChatHub> hc,
            IHubContext<AuthChatHub> ahc, IProductRepository repo)
        {
            _hubContext = hc;
            _authHubContext = ahc;
            _repo = repo;
        }

        [Authorize]
        public async Task<ActionResult<bool>> SendCommentAuth(
            [FromBody] Comments comment)
        {
            try
            {
                await _authHubContext.Clients.All.SendAsync(
                    "SendCommentAuth", comment.NameOfSender, comment.Text);
                await _repo.AddComment(comment);
                return true;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        public async Task<ActionResult<bool>> SendComment(
            [FromBody] Comments comment)
        {
            try
            {
                await _hubContext.Clients.All.SendAsync(
                    "SendComment", comment.NameOfSender, comment.Text);
                await _repo.AddComment(comment);
                return true;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
