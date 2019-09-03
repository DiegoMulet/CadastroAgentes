using CadastroAgentes.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroAgentes.Data.Mappings
{
    public class StatusMappings : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("numeric(3)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasData(new Status { Codigo = 1, Descricao = "Cadastro Prévio" },
                            new Status { Codigo = 2, Descricao = "Pendente" },
                            new Status { Codigo = 3, Descricao = "Encaminhado" },
                            new Status { Codigo = 4, Descricao = "Aprovado" });

            builder.ToTable("Status");
        }
    }
}
