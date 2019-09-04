using CadastroAgentes.Business.Models;
using System;
using System.Threading.Tasks;

namespace CadastroAgentes.Business.Interfaces
{
    public interface IFornecedorService : IDisposable
    {
        Task<bool> Adicionar(Fornecedor fornecedor);
        Task<bool> Atualizar(Fornecedor fornecedor);
        Task<bool> Remover(Guid id);
    }
}
