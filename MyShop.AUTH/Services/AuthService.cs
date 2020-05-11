using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyShop.AUTH.Interfaces;
using MyShop.AUTH.Models;
using MyShop.Core.EF;
using MyShop.Core.Services;
using MyShop.Data.Converters;
using MyShop.Data.Dto;
using MyShop.Data.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.AUTH.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IJwtGenerator _jwt;
        private readonly ShopDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(SignInManager<User> sim, UserManager<User> um, IJwtGenerator jwt, ShopDbContext context,
            IConfiguration configuration)
        {
            _signInManager = sim;
            _userManager = um;
            _jwt = jwt;
            _context = context;
            _configuration = configuration;
        }

        public async Task<Response<Token>> Login(string email, string password)
        {
            try
            {
                if (email == null || password == null)
                    return new Response<Token>(400, "Invalid email or password");

                var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

                if (result.Succeeded)
                {
                    var appUser = await _userManager.FindByEmailAsync(email);
                    if (!await _userManager.IsEmailConfirmedAsync(appUser))
                        return new Response<Token>(400, "Email is not confirmed");
                    return await _jwt.GenerateJwt(appUser);
                }
                return new Response<Token>(400, "Invalid email or password");
            }
            catch (Exception)
            {
                return new Response<Token>(520, "Unknown error");
            }
        }

        public async Task<Response<Token>> RefreshToken(string token, string refreshToken)
        {
            try
            {
                var principal = GetPrincipalFromExpiredToken(token);
                if (principal == null)
                    return new Response<Token>(400, "Invalid access token");
                var email = principal.Identity.Name;
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                    return new Response<Token>(404, "User not found");
                var dbToken = _context.RefreshTokens
                    .FirstOrDefault(rt => rt.UserId == user.Id && rt.Token == refreshToken);
                if (dbToken == null)
                    return new Response<Token>(400, "Invalid refresh token");
                if (dbToken.ExpiresDate < DateTime.Now)
                {
                    _context.RefreshTokens.Remove(dbToken);
                    await _context.SaveChangesAsync();
                    return new Response<Token>(400, "Expired refresh token");
                }
                var data = await _jwt.GenerateJwt(user);
                if (data.Succeeded())
                {
                    _context.RefreshTokens.Remove(dbToken);
                    await _context.SaveChangesAsync();
                }
                return data;
            }
            catch (Exception ex)
            {
                return new Response<Token>(520, "Unknown error");
            }
        }

        public async Task<Response<string>> Register(UserDto item, string role)
        {
            try
            {
                User user = UserConverter.Convert(item);
                if (user == null)
                  return new Response<string>(400, "Invalid email or password");

                var result = await _userManager.CreateAsync(user, item.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, role);
                    await SendConfirmation(user);
                    await _signInManager.SignInAsync(user, false);
                    return new Response<string>(200, "Get your token from message");
                }

                return new Response<string>(400, "Invalid data");
            }
            catch (Exception)
            {
                return new Response<string>(520, "Unknown error");
            }
        }
        public async Task SendConfirmation(User item)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(item);
            EmailService emailService = new EmailService();
            string text = "Подтвердите регистрацию, перейдя по ссылке: <a href='http://130.193.48.28/confirmation.html?conftoken=" + code+ "#"+item.Id+"'>link</a>";
            await emailService.SendEmailAsync(item.Email, "Confirm your account", text);
        }

        public async Task<Response<Token>> ConfirmEmail(string userId, string code)
        {
            try { 
                User user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    if (await _userManager.IsEmailConfirmedAsync(user))
                        return new Response<Token>(400, "Already confirmed");
                    var result = await _userManager.ConfirmEmailAsync(user, code);
                    if (result.Succeeded)
                        return await _jwt.GenerateJwt(user);
                }
                return new Response<Token>(400, "Invalid data");
            }
            catch (Exception)
            {
                return new Response<Token>(520, "Unknown error");
            }
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = _configuration["Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Issuer"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"])),
                    ValidateLifetime = false
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                                                            StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException();

                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

