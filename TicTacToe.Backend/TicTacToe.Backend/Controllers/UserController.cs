using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Data.Models;
using TicTacToe.Service.UserService;

namespace TicTacToe.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;

        [HttpGet]
        public List<Users> GetUserList()
        {
            return _userService.GetUserList();
        }

        [HttpGet]
        public Users GetUserById(Users input)
        {
            return _userService.GetUserById(input);
        }

        [HttpPost]
        public Users Insert(Users input)
        {
            return _userService.Insert(input);
        }

        [HttpPost]
        public Users Update(Users input)
        {
            return _userService.Update(input);
        }

        [HttpPost]
        public bool Delete(int id)
        {
            return _userService.Delete(id);
        }

    }
}