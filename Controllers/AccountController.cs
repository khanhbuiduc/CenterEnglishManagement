﻿using CenterEnglishManagement.Dto;
using CenterEnglishManagement.Models.UserModels;
using CenterEnglishManagement.Service.IService.IUserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CenterEnglishManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController:ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            // Xác thực người dùng từ cơ sở dữ liệu (bỏ qua phần này)
            // Giả sử bạn có một phương thức ValidateUser trả về một đối tượng User nếu hợp lệ
            var user = await _userService.ValidateUser(login.Email, login.Password);
            if (user == null)
            { return Unauthorized();
            }
            var token = GenerateJwtToken(user);
            HttpContext.Response.Cookies.Append("AuthToken", token);
            return Ok(new { token });

        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var expirationDate = jwtToken.ValidTo;

            return Ok(new { message = "Logged out successfully" });
        }
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("gkjhjhgggfdsgsgsgtdsgdsgdsgdssdgsdgdsjk");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Name), new Claim(ClaimTypes.Role, user.Role.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "jhjlkhljkljk",
                Audience = "cxzvknxzjvhjkk"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor); 
            HttpContext.Response.Cookies.Append("AuthToken", "");

            return tokenHandler.WriteToken(token);
        }
    }
}
