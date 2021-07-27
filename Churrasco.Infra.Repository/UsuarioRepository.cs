using Churrasco.Domain.Entities;
using Churrasco.Domain.Entities.Interfaces;
using Churrasco.Infra.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Churrasco.Infra.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventoChurrascoContext _db;
        public UsuarioRepository(EventoChurrascoContext db)
        {
            _db = db;
        }
        public void Adicionar(Usuario obj)
        {
            _db.Usuarios.Add(obj);
            _db.SaveChanges();
        }

        public void Editar(Usuario obj)
        {
            _db.Usuarios.Update(obj);
            _db.SaveChanges();
        }

        public List<Usuario> Obter()
        {
            return _db.Usuarios.ToList();
        }

        public Usuario ObterUsuarioSenha(string nomeDeUsuario, string senha)
        {
            return _db.Usuarios.Where(x => x.NomeDeUsuario == nomeDeUsuario && x.Senha == senha).FirstOrDefault();
        }

        public Usuario ObterPorId(int id)
        {
            return _db.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public void Remover(int id)
        {
            var obj = ObterPorId(id);
            _db.Remove(obj);
            _db.SaveChanges();
        }

    }
}
