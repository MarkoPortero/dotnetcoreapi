namespace MarksWebApp.Controllers
{
    using System.Collections.Generic;
    using MarksWebApp;
    using MarksWebApp.Models;
    using MarksWebApp.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    /*using StringValidators;*/

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            /*if(!UsernameValidator.ValidateAlphaNumeric(model.Username))
            {
                return BadRequest("Username not AlphaNumeric");
            }*/

            User user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<User> users = _userService.GetAll();
            return Ok(users);
        }
    }
}