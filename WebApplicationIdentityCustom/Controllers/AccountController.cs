using System;
using System.Web;
using System.Web.Mvc;
using WebApplicationIdentityCustom.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Security.Claims;

namespace WebApplicationIdentityCustom.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager UserMamager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();

        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed()
        {
            ApplicationUser user = await UserMamager.FindByEmailAsync(User.Identity.Name);

            if(user != null)
            {
                IdentityResult result = await UserMamager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Logout");
                }
            }
            return RedirectToAction("Index", "Home");

        }

        public async Task<ActionResult> Edit()
        {
            ApplicationUser user = await UserMamager
                                .FindByEmailAsync(User.Identity.Name);
            
            if(user != null)
            {
                EditModel model = new EditModel { Yeat = user.Year };
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditModel model)
        {
            ApplicationUser user = await UserMamager
                                            .FindByEmailAsync(User.Identity.Name);
            if(user != null)
            {
                user.Year = model.Yeat;
                IdentityResult  result = await UserMamager
                            .UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }

            return View(model);

        }


        public ActionResult Login(String returnUrl)
        {
            ViewBag.reurnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserMamager.FindAsync(model.Email, model.Password);

                if(user == null)
                {
                    ModelState.AddModelError("", "Неверный пароль или логин");
                }
                else
                {
                    ClaimsIdentity claim = await UserMamager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");

                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);

        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();

        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email, Year = model.Year };
                IdentityResult result = await UserMamager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }

            return View();


        }

        public ActionResult Index()
        {
            return View();
        }
    }
}