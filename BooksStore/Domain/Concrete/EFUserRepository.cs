using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    //Представляет хранилище. Реализует интерфес IUserRepository и использует BContext
    //для извлечения данных из бд

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
            if (user.Id == 0) //добавляет пользователя, если значение индекса равно 0
            {
                context.Users.Add(user);
            }
            else //изменение бд
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
