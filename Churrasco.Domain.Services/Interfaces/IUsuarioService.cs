using Churrasco.Domain.Entities;
using System.Collections.Generic;

namespace Churrasco.Domain.Services.Interfaces
{
    public interface IUsuarioService
    {

        string Authenticate(string nomeDeUsuario,string senha);
        Usuario GetById(int id);
        IEnumerable<Usuario> GetAll();
        string GenerateToken(Usuario user);

    }
}
