using Features.Clientes.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Features.Clientes
{
    public class ClienteService : IClienteService
    {
        #region Propriedades

        private readonly IClienteRepository _clienteRepository;
        private readonly IMediator _mediator;

        #endregion

        #region Construtor

        public ClienteService(IClienteRepository clienteRepository,
                              IMediator mediator)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
        }

        #endregion

        #region Metodos

        public IEnumerable<Cliente> ObterTodosAtivos()
        {
            return _clienteRepository.ObterTodos().Where(c => c.Ativo);
        }

        public void Adicionar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return;

            _clienteRepository.Adicionar(cliente);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, "Olá", "Bem vindo!"));
        }

        public void Atualizar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return;

            _clienteRepository.Atualizar(cliente);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, "Mudanças", "Dê uma olhada!"));
        }

        public void Inativar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return;

            cliente.Inativar();
            _clienteRepository.Atualizar(cliente);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, "Até breve", "Até mais tarde!"));
        }

        public void Remover(Cliente cliente)
        {
            _clienteRepository.Remover(cliente.Id);
            _mediator.Publish(new ClienteEmailNotification("admin@me.com", cliente.Email, "Adeus", "Tenha uma boa jornada!"));
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

        #endregion
    }
}
