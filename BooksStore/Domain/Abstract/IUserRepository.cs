using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; } //получаем последовательность всех пользователей
        void SaveUser(User user);
    }
}
