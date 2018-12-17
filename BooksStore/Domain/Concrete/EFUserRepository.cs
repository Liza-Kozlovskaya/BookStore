using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFUserRepository : IUserRepository 
    {
        BContext context = new BContext();
        public IEnumerable<User> Users
        {
            get
            {
                return context.Users;
            }
        }

        public void SaveUser(User user)
        {
            if (user.Id == 0)
            {
                context.Users.Add(user);
            }
            else
            {
                User dbEntry = context.Users.Find(user.Id);
                if (dbEntry != null)
                {
                    dbEntry.Email = user.Email;
                    dbEntry.Password = user.Password;
                    dbEntry.Age = user.Age;
                    dbEntry.RoleId = user.RoleId;
                }
            }
            context.SaveChanges();
        }
    }
}
