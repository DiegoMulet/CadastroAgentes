using CadastroAgentes.Business.Models;
using System.Threading.Tasks;

namespace CadastroAgentes.Business.Interfaces
{
    public interface IStatusRepository : IRepository<Status>
    {
        Task<Status> ObterPorCodigo(int codigo);
    }
}
