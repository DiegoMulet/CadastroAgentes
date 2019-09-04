using CadastroAgentes.Business.Interfaces;
using CadastroAgentes.Business.Models;
using System;
using System.Threading.Tasks;

namespace CadastroAgentes.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IStatusRepository _statusRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository,
                                 IStatusRepository statusRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _statusRepository = statusRepository;
        }
        public async Task<bool> Adicionar(Fornecedor fornecedor)
        {
            var status = await _statusRepository.ObterPorCodigo((int)Status.CodigoStatus.CadastroPrevio);
            fornecedor.StatusId = status.Id;
            //fornecedor.Status = null;
            _fornecedorRepository.Adicionar(fornecedor);

            return (await _fornecedorRepository.SaveChanges()) > 0;

        }
        public async Task<bool> Atualizar(Fornecedor fornecedor)
        {
            _fornecedorRepository.Atualizar(fornecedor);
            return (await _fornecedorRepository.SaveChanges()) > 0;
        }       
        public async Task<bool> Remover(Guid id)
        {
            _fornecedorRepository.Remover(id);
            return (await _fornecedorRepository.SaveChanges()) > 0;
        }
        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
        }
    }
}
