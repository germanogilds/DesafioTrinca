using Churrasco.Domain.Entities;
using Churrasco.Domain.Entities.Interfaces;
using Churrasco.Infra.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Churrasco.Infra.Repository
{
    public class ParticipanteRepository : IParticipanteRepository
    {
        private readonly EventoChurrascoContext _db;
        public ParticipanteRepository(EventoChurrascoContext db)
        {
            _db = db;
        }
        public void Adicionar(Participante obj)
        {
            _db.Participantes.Add(obj);
            _db.SaveChanges();
        }

        public void Editar(Participante obj)
        {
            _db.Participantes.Update(obj);
            _db.SaveChanges();
        }

        public List<Participante> Obter()
        {
            return _db.Participantes.ToList();
        }
           

        public Participante ObterPorId(int id)
        {
            return _db.Participantes.FirstOrDefault(x => x.Id== id);
        }
        public List<Participante> ObterParticipantesDoEventoChurrascoPorId(int id)
        {
            return _db.Participantes.Where(x => x.Id == id).ToList();
        }

        public void Remover(int id)
        {
            var obj = ObterPorId(id);
            _db.Remove(obj);
            _db.SaveChanges();
        }
    }
}
