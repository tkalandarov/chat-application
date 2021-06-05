using ChatApplication.Data;
using ChatApplication.Hubs;
using ChatApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Controllers
{
    public class ChatController : Controller
    {
        private readonly DataContext db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(DataContext dataContext, UserManager<IdentityUser> userManager, IHubContext<ChatHub> hubContext)
        {
            db = dataContext;
            _userManager = userManager;
            _hubContext = hubContext;
        }
        public async Task<IActionResult> SendMessage(string to, string text)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return StatusCode(500);
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var recipient = await db.Users.SingleOrDefaultAsync(x => x.UserName == to);

            Message message = new Message()
            {
                FromUserId = user.Id,
                ToUserId = recipient.Id,
                Text = text,
                Timestamp = DateTime.Now
            };
            await db.AddAsync(message);
            await db.SaveChangesAsync();

            string connectionId = ChatHub.UsernameConnectionId[recipient.UserName];

            await _hubContext.Clients.Client(connectionId).SendAsync("RecieveMessage", message.Text, message.Timestamp.ToShortTimeString());

            return Ok();
        }
    }
}
