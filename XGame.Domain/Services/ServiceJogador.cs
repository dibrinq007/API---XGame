using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;

namespace XGame.Domain.Services
{
    class ServiceJogador : IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public ServiceJogador()
        {

        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            Guid id = _repositoryJogador.AdicionarJogador(request);

            return new AdicionarJogadorResponse() { Id = id, Message = "Operação realizada com sucesso" };

        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                throw new Exception("AutenticarJogadorRequest é obrigatório!!");
            }
            
            if (string.IsNullOrEmpty(request.Email))
            {
                throw new Exception("Informe um Email");
            }

            if (isEmail(request.Email))
            {
                throw new Exception("Informe um Email");
            }

            if (string.IsNullOrEmpty(request.Senha))
            {
                throw new Exception("Informe uma Senha");
            }

            if (request.Senha.Length <= 6)
            {
                throw new Exception("Digite uma senha de no mínimo 6 caracteres");
            }

            var response = _repositoryJogador.AutenticarJogador(request);

            return response;
        }

        private bool isEmail(string email)
        {
            return false;
        }
    }
}
