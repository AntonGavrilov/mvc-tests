using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplicationIdentityCustom.Models
{
    public class ApplicationRole: IdentityRole
    {
        public string Description { get; set; }

    }
}