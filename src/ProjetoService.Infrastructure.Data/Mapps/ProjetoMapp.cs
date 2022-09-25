using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoService.Domain.Entities;

namespace ProjetoService.Infrastructure.Data.Mapps
{
    public class ProjetoMapp : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("tb_projeto", "Kanban");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("cd_projeto_pk").ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Descricao).HasColumnName("nm_descricao").IsRequired();
        }
    }
}
