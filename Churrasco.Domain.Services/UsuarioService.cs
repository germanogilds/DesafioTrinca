using Churrasco.Domain.Entities;
using Churrasco.Domain.Entities.Interfaces;
using Churrasco.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text; 

namespace Churrasco.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {

        private IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _config;
        public UsuarioService(IUsuarioRepository usuarioRepository,IConfiguration config)
        {
            _usuarioRepository = usuarioRepository;
            _config = config;
        }


        private List<Usuario> _users = new List<Usuario>
        {
            new Usuario { Id = 1,  NomeDeUsuario = "nome", Senha = "senha" }
        };
        public string Authenticate(string nomeDeUsuario, string senha)
        {
            var usuario = _users.FirstOrDefault(x => x.NomeDeUsuario == nomeDeUsuario && x.Senha == senha);
            if (usuario == null)
            {
                return string.Empty;
            }
            var token = GenerateToken(usuario);
     
            return token;
        }
        public Usuario GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _users.ToList();
        }


        public string GenerateToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
