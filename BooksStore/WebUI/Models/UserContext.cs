using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }

    public class UserObInitializer : CreateDatabaseIfNotExists<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            db.Roles.Add(new Role { Id = 1, Name = "admin" });
            db.Roles.Add(new Role { Id = 2, Name = "user" });
            db.Roles.Add(new Role { Id = 3, Name = "moder" });
            db.Users.Add(new User
            {
                Id = 1,
                Email = "admin@gmail.com",
                Password="123456",
                Age=20,
                RoleId=1
            });
            db.Users.Add(new User
            {
                Id = 3,
                Email = "moder@gmail.com",
                Password = "123456",
                Age = 23,
                RoleId = 3
            });
            base.Seed(db);
        }
    }
}