using Application.Dto;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    /*!!!*/
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [SwaggerOperation(Summary = "Register a new user")]
        [HttpPost]
        public IActionResult Create(RegisterUserDto newUser)
        {
            var user = _userService.AddNewUser(newUser);
            return Created($"api/users/(user.Id)", user);
        }
    }
}
