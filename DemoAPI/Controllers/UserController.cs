using BLL.Interface;
using BLL.Models;
using DemoAPI.Infrastructure;
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
        private readonly TokenManager _tokenManager;

        public UserController(ILocalUserService localUserService, TokenManager tokenManager)
        {
            _localUserService = localUserService;
            _tokenManager = tokenManager;
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
        public IActionResult Login(LoginForm form)
        {
            User u = _localUserService.Login(form.Email, form.Password);
            ConnectedUser cu = new ConnectedUser
            {
                Id = u.Id,
                NickName = u.NickName,
                Token = _tokenManager.GenerateToken(u)
            };

            return Ok(cu);
        }

        [HttpDelete] 
        public IActionResult Ban(int id)
        {
            _localUserService.BanUser(id);
            return Ok();
        }
    }
}
