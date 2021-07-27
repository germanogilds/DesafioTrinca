using Churrasco.Domain.Entities;
using Churrasco.Domain.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Churrasco.Domain.Services.Interfaces
{
    public interface IEventoChurrascoService
    {

        void AdicionarEventoChurrasco(EventoChurrasco eventoChurrasco);

        void EditarEventoChurrasco(EventoChurrasco eventoChurrasco);

        void RemoverEventoChurrasco(int id);

        List<EventoChurrasco> ObterEventosChurrascos();

        EventoChurrasco ObterPorIdEventoChurrasco(int id);
        EventoChurrascoDto ObterDetalheEventoChurrasco(int id);


    }
}
