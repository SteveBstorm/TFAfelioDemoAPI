using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ILocalUserService
    {
        IEnumerable<User> GetAll();
        User Login(string email, string password);
        bool RegisterUser(string nickname, string email, string password);
    }
}
