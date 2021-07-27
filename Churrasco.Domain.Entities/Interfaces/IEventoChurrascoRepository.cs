using System.Collections.Generic;

namespace Churrasco.Domain.Entities.Interfaces
{
    public interface IEventoChurrascoRepository
    {
        void Adicionar(EventoChurrasco obj);
        void Editar(EventoChurrasco obj);
        EventoChurrasco ObterPorId(int id);
        List<EventoChurrasco> Obter();
        void Remover(int id);
    }
}
