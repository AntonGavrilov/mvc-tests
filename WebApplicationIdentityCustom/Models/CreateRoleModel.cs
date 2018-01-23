using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationIdentityCustom.Models
{
    public class CreateRoleModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}