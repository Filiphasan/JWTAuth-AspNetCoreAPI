using JWTExample.Core.Dtos;
using JWTExample.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var result = await _userService.CreateUserAsync(createUserDto);
            return ActionResultInstance(result);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var result = await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name);
            return ActionResultInstance(result);
        }
    }
}
