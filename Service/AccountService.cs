using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using TodoAPI.Model;
using TodoAPI.Model.Dtos;
using TodoAPI.Utility;

namespace TodoAPI.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokensGeneratorService _tokenService;
        public AccountService(UserManager<AppUser> userManager, ITokensGeneratorService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<LoginResponse> Login(UserLoginModel model)
        {
             var user = await _userManager.FindByEmailAsync(model.Email);
            var check = await _userManager.CheckPasswordAsync(user, model.Password);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return null;

            var token = await _tokenService.GenerateTokenAsync(user);
            return new LoginResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Token = token
            };
        }

        public async Task<string> Register(UserRegistrationModel model)
        {
            var user = new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Email,
                CreatedAt = DateTime.UtcNow,
                EmailConfirmed = true
            };
            var userCreationResult = await _userManager.CreateAsync(user, model.Password);
            if (!userCreationResult.Succeeded)
                return "Registration not successful";

            return "Registration Successful";
        }
    }
}
