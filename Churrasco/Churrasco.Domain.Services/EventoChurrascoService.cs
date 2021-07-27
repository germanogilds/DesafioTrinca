using Churrasco.Domain.Entities;
using Churrasco.Domain.Entities.Dtos;
using Churrasco.Domain.Entities.Interfaces;
using Churrasco.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Churrasco.Domain.Services
{
    public class EventoChurrascoService : IEventoChurrascoService
    {
        private IEventoChurrascoRepository _eventoChurrascoRepository;

        public EventoChurrascoService(IEventoChurrascoRepository eventoChurrascoRepository)
        {
            _eventoChurrascoRepository = eventoChurrascoRepository;
        }
        public void AdicionarEventoChurrasco(EventoChurrasco eventoChurrasco)
        {
            _eventoChurrascoRepository.Adicionar(eventoChurrasco);
        }

        public void EditarEventoChurrasco(EventoChurrasco eventoChurrasco)
        {
            _eventoChurrascoRepository.Editar(eventoChurrasco);
        }

        public List<EventoChurrasco> ObterEventosChurrascos()
        {
            return _eventoChurrascoRepository.Obter();
        }

        public EventoChurrasco ObterPorIdEventoChurrasco(int id)
        {
            return _eventoChurrascoRepository.ObterPorId(id);
        }

        public void RemoverEventoChurrasco(int id)
        {
            _eventoChurrascoRepository.Remover(id);
        }

        public EventoChurrascoDto ObterDetalheEventoChurrasco(int id)
        {

            var obj = new EventoChurrascoDto();

            obj.EventoChurrasco = _eventoChurrascoRepository.ObterPorId(id);
            obj.TotalDeParticipante = obj.EventoChurrasco.Participantes.Count;
            obj.ValorArrecadado = obj.EventoChurrasco.Participantes.Where(x => x.ValorPago != null).Sum(x => x.ValorPago.Value);
            
            return obj;
        }
    }
}
