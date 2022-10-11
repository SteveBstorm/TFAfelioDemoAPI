using BLL.Interface;
using BLL.Mappers;
using BLL.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LocalUserService : ILocalUserService
    {
        private readonly IUserService _userService;
        public LocalUserService(IUserService service)
        {
            _userService = service;
        }

        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll().Select(x => x.ToBll());
        }

        public User Login(string email, string password)
        {
            return _userService.Login(email, password).ToBll();
        }

        public bool RegisterUser(string nickname, string email, string password)
        {
            return _userService.RegisterUser(nickname, email, password);
        }

        public void BanUser(int id)
        {
            _userService.BanUser(id);
        }
    }
}
