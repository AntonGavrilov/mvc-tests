using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxChat.Models
{
    public class ChatModel
    {
        public List<ChatUser> Users;
        public List<ChatMessage> Messages;
        
        public ChatModel()
        {
            Users = new List<ChatUser>();
            Messages = new List<ChatMessage>();
            Messages.Add(new ChatMessage { Text = string.Concat("Чат запущен {0}", DateTime.Now)});
        }


    }
}