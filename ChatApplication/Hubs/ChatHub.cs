using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApplication.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Hubs
{
    public class ChatHub : Hub
    {
        private readonly DataContext db;
        public static Dictionary<string, string> UsernameConnectionId = new();

        public ChatHub(DataContext dataContext)
        {
            db = dataContext;
        }
        public async Task<string> GetConnectionId(string username)
        {
            var user = await db.Users.SingleOrDefaultAsync(x => x.UserName == username);

            if (UsernameConnectionId.ContainsKey(username))
            {
                UsernameConnectionId[username] = Context.ConnectionId;
            }
            else
            {
                UsernameConnectionId.Add(username, Context.ConnectionId);
            }

            return Context.ConnectionId;
        }
    }
}
