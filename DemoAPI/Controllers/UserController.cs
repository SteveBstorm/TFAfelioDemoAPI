using BLL.Interface;
using DemoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILocalUserService _localUserService;

        public UserController(ILocalUserService localUserService)
        {
            _localUserService = localUserService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_localUserService.GetAll());
        }

        [HttpPost("register")]
        public IActionResult Register(UserForm u)
        {
            return Ok(_localUserService.RegisterUser(u.NickName, u.Email, u.Password));
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            return Ok(_localUserService.Login(email, password));
        }

        [HttpDelete] 
        public IActionResult Ban(int id)
        {
            _localUserService.BanUser(id);
            return Ok();
        }
    }
}
