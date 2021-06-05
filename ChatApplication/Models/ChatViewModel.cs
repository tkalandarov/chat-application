using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.Models
{
    public class ChatViewModel
    {
        public string RecipientName { get; set; }
        public List<Message> MyMessages { get; set; }
        public List<Message> OtherMessages { get; set; }
        public Message LastMessage { get; set; }
    }
}
