using Churrasco.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using Churrasco.Domain.Entities;
using Churrasco.Infra.Repository.Context;
using System.Linq;

namespace Churrasco.Infra.Repository
{
    public class EventoChurrascoRepository : IEventoChurrascoRepository
    {
        private readonly EventoChurrascoContext _db;
        IParticipanteRepository _participanteRepository;
        public EventoChurrascoRepository(EventoChurrascoContext db, IParticipanteRepository participanteRepository)
        {
            _db = db;
            _participanteRepository = participanteRepository;
        }
        public void Adicionar(EventoChurrasco obj)
        {
            _db.EventoChurrascos.Add(obj);
            _db.SaveChanges();
        }

        public void Editar(EventoChurrasco obj)
        {
            _db.EventoChurrascos.Update(obj);
            _db.SaveChanges();
        }

        public List<EventoChurrasco> Obter()
        {
            return _db.EventoChurrascos.ToList();
        }

        public EventoChurrasco ObterPorId(int id)
        {
            return _db.EventoChurrascos.FirstOrDefault(x => x.Id == id);
        }

        public EventoChurrasco ObterDetalhesdoPorId(int id)
        {
            return _db.EventoChurrascos.FirstOrDefault(x => x.Id == id);
        }


        public void Remover(int id)
        {
            var obj = ObterPorId(id);
            _db.Remove(obj);
            _db.SaveChanges();
        }
    }
}
