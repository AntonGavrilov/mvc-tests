using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplicationProviders.Models;

namespace WebApplicationProviders.Controllers
{
    public class AccountController : Controller
    {
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(loginModel.UserName, loginModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginModel.UserName, loginModel.RememberMe);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль или логин");
                }
            }

            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel RegisterModel)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus createStatus;
                Membership.CreateUser(RegisterModel.UserName, RegisterModel.Password, RegisterModel.Email,
                    passwordQuestion: null, passwordAnswer: null, isApproved: true,
                    providerUserKey: null, status: out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(RegisterModel.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка при регистрации");
                }
            }

            return View(RegisterModel);
        }
    }
}