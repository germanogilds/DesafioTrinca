using System.Collections.Generic;

namespace Churrasco.Domain.Entities.Interfaces
{
    public interface IParticipanteRepository
    {
        void Adicionar(Participante obj);
        void Editar(Participante obj);
        Participante ObterPorId(int id);
        List<Participante> Obter();
        void Remover(int id);
        List<Participante> ObterParticipantesDoEventoChurrascoPorId(int id);
    }
}
