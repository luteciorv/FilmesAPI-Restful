using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class TokenService
    {
        public Token CriarToken(IdentityUser<int> usuario, string cargo)
        {
            Claim[] direitosUsuarios = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, cargo)
            };

            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09sdj"
                ));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                claims: direitosUsuarios,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString);
        }       
    }
}
