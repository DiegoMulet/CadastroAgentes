using CadastroAgentes.Business.Interfaces;
using CadastroAgentes.Business.Models;
using CadastroAgentes.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAgentes.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(CadastroAgentesContext context) : base(context) { }

        public async Task<IEnumerable<Fornecedor>> ObterTodos()
        {
            IQueryable<Fornecedor> query = Db.Fornecedores
                .Include(f => f.Status);

            query = query.OrderBy(c => c.Nome);

            return await query.ToListAsync();

        }
    }
}
