using CadastroAgentes.Business.Interfaces;
using CadastroAgentes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAgentes.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IStatusRepository _statusRepository;

        public ClienteService(IClienteRepository clienteRepository,
            IStatusRepository statusRepository)
        {
            _clienteRepository = clienteRepository;
            _statusRepository = statusRepository;
        }
        public async Task<bool> Adicionar(Cliente cliente)
        {
            var status = await _statusRepository.ObterPorCodigo((int)Status.CodigoStatus.CadastroPrevio);
            cliente.StatusId = status.Id;
            _clienteRepository.Adicionar(cliente);

            return (await _clienteRepository.SaveChanges()) > 0;

        }
        public async Task<bool> Atualizar(Cliente cliente)
        {
            _clienteRepository.Atualizar(cliente);
            return (await _clienteRepository.SaveChanges()) > 0;
        }       
        public async Task<bool> Remover(Guid id)
        {
            _clienteRepository.Remover(id);
            return (await _clienteRepository.SaveChanges()) > 0;
        }
        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
