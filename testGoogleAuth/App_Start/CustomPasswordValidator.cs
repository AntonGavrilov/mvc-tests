using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Text.RegularExpressions;

namespace testGoogleAuth.App_Start
{
    public class CustomPasswordValidator : IIdentityValidator<string>
    {
        public int RequiredLength { get; set; }

        Task<IdentityResult> IIdentityValidator<string>.ValidateAsync(string item)
        {
            if(string.IsNullOrEmpty(item) || item.Length < RequiredLength)
            {
                return Task.FromResult(IdentityResult.Failed(
                    String.Format("Минимальная длина пароля равна {0}", RequiredLength)));
            }

            string pattern = "^[0-9]+$";

            if(!Regex.IsMatch(item, pattern))
            { 
                return Task.FromResult(IdentityResult.Failed("Пароль должен состоять только из цифр"));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}