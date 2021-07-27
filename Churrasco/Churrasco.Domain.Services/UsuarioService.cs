using Churrasco.Domain.Entities;
using Churrasco.Domain.Entities.Interfaces;
using Churrasco.Domain.Services.Interfaces;
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
        //private readonly  AppSettings _appSettings;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        private List<Usuario> _users = new List<Usuario>
        {
            new Usuario { Id = 1, /*FirstName = "Test", LastName = "User",*/ NomeDeUsuario = "nome", Senha = "senha" }
        };
        public string Authenticate(string nomeDeUsuario, string senha)
        {
            //var usuario = _usuarioRepository.ObterUsuarioSenha(nomeDeUsuario, senha);
            var usuario = _users.FirstOrDefault(x => x.NomeDeUsuario == nomeDeUsuario && x.Senha == senha);
            if (usuario == null)
            {
                return string.Empty;
            }
            var token = generateJwtToken(usuario);
     
            return token;
        }

        //public Usuario GetById(int id)
        //{
        //    return _usuarioRepository.ObterPorId(id);
        //}
        //public IEnumerable<Usuario> GetAll()
        //{
        //    return _usuarioRepository.Obter();
        //}
        public Usuario GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _users.ToList();
        }

        private string generateJwtToken(Usuario usuario)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("4673B7EA64A041D5B3668321D394E29D"/*_appSettings.Secret*/);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", usuario.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
