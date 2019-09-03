using CadastroAgentes.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroAgentes.Data.Mappings
{
    public class ClienteMappings : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Altura)
                .IsRequired()
                .HasColumnType("numeric(3,2)");

            builder.Property(p => p.Peso)
                .IsRequired()
                .HasColumnType("numeric(6,3)");

            builder.Property(p => p.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.Endereco)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.DataTerminoAnalise)
                .HasColumnType("datetime");

            builder.HasOne(f => f.Status);

            builder.ToTable("Clientes");
        }
    }
}
