using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebApplicationIdentityCustom.Models;
using System.Threading.Tasks;


namespace WebApplicationIdentityCustom.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext()
                        .GetUserManager<ApplicationRoleManager>();
            }
        }

        // GET: Role
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await RoleManager.CreateAsync(new ApplicationRole
                {
                    Name = model.Name,
                    Description = model.Description

                });

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }else
                {
                    result.Errors.ToList()
                        .ForEach(e => ModelState.AddModelError("",e));
                }
            }

            return View(model);
        }

        public async Task<ActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);

            if(role != null)
            {
                IdentityResult result = await RoleManager.DeleteAsync(role);
            }
            return RedirectToAction("index");
        }
    }
}