using ChatApplication.Data;
using ChatApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext db;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(DataContext dataContext, UserManager<IdentityUser> userManager)
        {
            db = dataContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var allMessages = await db.Messages.Where(x =>
                x.FromUserId == user.Id ||
                x.ToUserId == user.Id)
                .ToListAsync();

            var chats = new List<ChatViewModel>();
            foreach (var i in await db.Users.ToListAsync())
            {
                if (i == user) continue;

                var chat = new ChatViewModel()
                {
                    MyMessages = allMessages.Where(x => x.FromUserId == user.Id && x.ToUserId == i.Id).ToList(),
                    OtherMessages = allMessages.Where(x => x.FromUserId == i.Id && x.ToUserId == user.Id).ToList(),
                    RecipientName = i.UserName
                };

                var chatMessages = new List<Message>();
                chatMessages.AddRange(chat.MyMessages);
                chatMessages.AddRange(chat.OtherMessages);

                chat.LastMessage = chatMessages.OrderByDescending(x => x.Timestamp).FirstOrDefault();

                chats.Add(chat);
            }

            return View(chats);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
