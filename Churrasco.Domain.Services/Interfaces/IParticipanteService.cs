using Churrasco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Churrasco.Domain.Services.Interfaces
{
    public interface IParticipanteService
    {
        string AdicionarParticipante(Participante participante);

        string EditarParticipante(Participante participante);

        void RemoverParticipante(int id);

        List<Participante> ObterParticipantes();

        Participante ObterPorIdParticipante(int id);
    }
}
