using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TodoAPI.Data.Model;
using System;
using TodoAPI.Model;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using TodoAPI.Model.Dtos;
using TodoAPI.Service;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountService _accountService;

        public AuthController(IConfiguration configuration, IAccountService accountService)
        {
            _configuration = configuration;
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationModel request)
        {
            var result = await _accountService.Register(request);
            if (result == "Registration not successful")
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginModel model)
        {
            var result = await _accountService.Login(model);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }

       
    }
}
