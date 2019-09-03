using CadastroAgentes.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroAgentes.Data.Mappings
{
    public class FornecedorMappings : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.QtdFuncionarios)
                .IsRequired()
                .HasColumnType("numeric(10)");            

            builder.Property(p => p.DataAbertura)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.Endereco)
                .IsRequired()
                .HasColumnType("varchar(200)");            

            builder.Property(p => p.DataTerminoAnalise)
                .HasColumnType("datetime");

            builder.HasOne(f => f.Status);

            builder.ToTable("Fornecedores");
        }
    }
}
