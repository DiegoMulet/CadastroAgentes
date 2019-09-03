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

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<bool> Adicionar(Cliente cliente)
        {
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
