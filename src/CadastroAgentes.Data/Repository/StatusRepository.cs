using CadastroAgentes.Business.Interfaces;
using CadastroAgentes.Business.Models;
using CadastroAgentes.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAgentes.Data.Repository
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(CadastroAgentesContext context) : base(context) { }

        public async Task<Status> ObterPorCodigo(int codigo)
        {
            IQueryable<Status> query = Db.Status;

            return await query.FirstOrDefaultAsync(s => s.Codigo == codigo);

        }
    }
}
