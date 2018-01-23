using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplicationOWINClaimsIdentity.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }

    public class UserDBInitilizer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            context.Roles.Add(new Role { Id = 1, Name = "admin" });
            context.Roles.Add(new Role { Id = 2, Name = "user" });
            context.Users.Add(new User
            {
                Email = "gavranton@gmail.com",
                Password = "123456",
                RoleId = 2
            });

            context.Users.Add(new User
            {
                Email = "user1@gmail.com",
                Password = "12345",
                RoleId = 2
            });

            base.Seed(context);
        }
    }
       
}