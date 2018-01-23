using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxChat.Models;

namespace AjaxChat.Controllers
{
    public class HomeController : Controller
    {
        static ChatModel chatModel;

        public ActionResult Index(string user, bool? logOn, bool? logOff, string chatMessage)
        {


            try
            {
                if (chatModel == null) chatModel = new ChatModel();

                if (chatModel.Messages.Count > 100)
                    chatModel.Messages.RemoveRange(0, 90);

                if (!Request.IsAjaxRequest())
                {
                    return View(chatModel);
                }
                else if (logOn != null && (bool)logOn)
                {
                    if (chatModel.Users.FirstOrDefault(u => u.Name == user) != null)
                    {
                        throw new Exception("Пользователь с таким ником уже существует");
                    }
                    else if (chatModel.Users.Count > 10)
                    {
                        throw new Exception("Чат заполнен");
                    }
                    else
                        chatModel.Users.Add(new ChatUser()
                        {
                            Name = user,
                            LoginTime = DateTime.Now,
                            LastPing = DateTime.Now
                        });

                    return PartialView("ChatRoom", chatModel);
                }
                else if (logOff != null && (bool)logOff)
                {
                    this.LogOff(chatModel.Users.FirstOrDefault(u => u.Name == user));
                }
                else
                {
                    ChatUser currentUser = chatModel.Users.FirstOrDefault(u => u.Name == user);

                    currentUser.LastPing = DateTime.Now;

                    chatModel.Users.Where(u => (DateTime.Now - u.LastPing).TotalSeconds > 15)
                        .ToList()
                        .ForEach(u => this.LogOff(u));

                    if (!string.IsNullOrEmpty(chatMessage))
                    {
                        chatModel.Messages.Add(new ChatMessage()
                        {
                            User = currentUser,
                            Text = chatMessage,
                            Date = DateTime.Now
                        });
                    }

                    return PartialView("History", chatModel);
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;

                return Content(ex.Message);
            }

 

            return PartialView("ChatRoom", chatModel);
        }
        

    public void LogOff(ChatUser user)
    {
        chatModel.Users.Remove(user);
        chatModel.Messages.Add(new ChatMessage()
        {
            Text = user.Name + " покинул чат.",
            Date = DateTime.Now
        });
    }



    public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}