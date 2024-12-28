using BlogDAL.Context;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.Repostories
{
    public class AuthService
    {
        private readonly string _jwtKey;
        private readonly AppDbContext _context;

        public AuthService(string jwtKey, AppDbContext context)
        {
            _jwtKey = jwtKey;
            _context = context;
        }

        public async Task<bool> Register(RegisterDto dto)
        {
            if (_context.Users.Any(u => u.Username == dto.Username)) return false;

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var user = new User { Username = dto.Username, PasswordHash = passwordHash };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public string Login(LoginDto dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == dto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Username) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
