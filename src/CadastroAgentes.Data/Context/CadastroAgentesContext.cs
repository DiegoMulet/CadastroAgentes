using CadastroAgentes.Business.Models;
using CadastroAgentes.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CadastroAgentes.Data.Context
{
    public class CadastroAgentesContext : DbContext
    {
        public CadastroAgentesContext(DbContextOptions<CadastroAgentesContext> options) : base(options) { }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Status> Status { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastroAgentesContext).Assembly);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new StatusMappings());
        }
    }
}
