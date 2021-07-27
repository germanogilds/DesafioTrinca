using Churrasco.Domain.Entities;
using Churrasco.Domain.Entities.Interfaces;
using Churrasco.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Churrasco.Domain.Services
{
    public class ParticipanteService : IParticipanteService
    {
        IParticipanteRepository _participanteRepository;
        IEventoChurrascoRepository _eventoChurrascoRepository;

        public ParticipanteService(IParticipanteRepository participanteRepository, IEventoChurrascoRepository eventoChurrascoRepository)
        {
            _participanteRepository = participanteRepository;
            _eventoChurrascoRepository = eventoChurrascoRepository;
        }
        public string AdicionarParticipante(Participante participante)
        {
            string mensagem;
            var eventoChurrasco = _eventoChurrascoRepository.ObterPorId(participante.ChurrascoId);

            mensagem = participante.ExisteChurrascoParaParticipante(eventoChurrasco);
            if (mensagem != string.Empty)
            {
                return mensagem;
            }

            mensagem = participante.VerificaValorPago(participante, eventoChurrasco);
            if (mensagem != string.Empty)
            {
                return mensagem;
            }

            _participanteRepository.Adicionar(participante);

            return string.Empty;
        }

        public string EditarParticipante(Participante participante)
        {
            string mensagem;
            var eventoChurrasco = _eventoChurrascoRepository.ObterPorId(participante.Id);

            mensagem = participante.ExisteChurrascoParaParticipante(eventoChurrasco);
            if (mensagem != string.Empty)
            {
                return mensagem;
            }

            mensagem = participante.VerificaValorPago(participante, eventoChurrasco);
            if (mensagem != string.Empty)
            {
                return mensagem;
            }
            _participanteRepository.Editar(participante);

            return string.Empty;
        }

        public List<Participante> ObterParticipantes()
        {
            return _participanteRepository.Obter();
        }

        public Participante ObterPorIdParticipante(int id)
        {
            return _participanteRepository.ObterPorId(id);
        }

        public void RemoverParticipante(int id)
        {
            _participanteRepository.Remover(id);
        }

    }
}
