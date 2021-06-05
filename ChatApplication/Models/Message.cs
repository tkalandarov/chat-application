using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }

        public string FromUserId { get; set; }
        public IdentityUser FromUser { get; set; }

        public string ToUserId { get; set; }
        public IdentityUser ToUser { get; set; }
    }
}
