using CadastroAgentes.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAgentes.Business.Interfaces
{
    public interface IClienteService : IDisposable
    {
        Task<bool> Adicionar(Cliente cliente);
        Task<bool> Atualizar(Cliente cliente);
        Task<bool> Remover(Guid id);
    }
}
