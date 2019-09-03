using CadastroAgentes.Business.Interfaces;
using CadastroAgentes.Business.Models;
using CadastroAgentes.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAgentes.Data.Repository
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(CadastroAgentesContext context) : base(context) { }
    }
}
