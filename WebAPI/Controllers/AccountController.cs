using Application.Dto;
using Application.Interfaces;
using Application.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<RegisterUserDto> _registerUserValidator;

        public AccountController(IUserService userService, IValidator<RegisterUserDto> registerUserValidator)
        {
            _userService = userService;
            _registerUserValidator = registerUserValidator;
        }

        [SwaggerOperation(Summary = "Register a new user")]
        [HttpPost("Register")]
        public IActionResult Create(RegisterUserDto newUser)
        {
            var validationResult = _registerUserValidator.Validate(newUser);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var user = _userService.AddNewUser(newUser);
            return Created($"api/users/{user.Id}", user);
        }

        [SwaggerOperation(Summary = "Login to an existing account")]
        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginUser)
        {
            string token = _userService.GenerateJwt(loginUser);
            return Ok(token);
        }
    }
}
