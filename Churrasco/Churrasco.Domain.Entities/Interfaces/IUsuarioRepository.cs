using System.Collections.Generic;

namespace Churrasco.Domain.Entities.Interfaces
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario obj);
        void Editar(Usuario obj);
        Usuario ObterPorId(int id);
        List<Usuario> Obter();
        void Remover(int id);
        Usuario ObterUsuarioSenha(string nomeDeUsuario, string senha);
    }
}
