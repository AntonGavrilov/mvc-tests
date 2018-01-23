using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using testGoogleAuth.Models;

namespace testGoogleAuth.App_Start
{
    public class CustomUserValidator : UserValidator<ApplicationUser>
    {
        public CustomUserValidator(UserManager<ApplicationUser, string> manager) : base(manager)
        {
            AllowOnlyAlphanumericUserNames = false;
        }

        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            var result = await base.ValidateAsync(user);

            if (user.Email.ToLower().EndsWith("@spam.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Данный домен находится в спам-листе");
                result = new IdentityResult(errors);
            }

            if (user.UserName.Contains("admin"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Ник пользователя не должен содержать слово 'admin'");
                result = new IdentityResult(errors);
            }

            return result;
            
        }
    }
}