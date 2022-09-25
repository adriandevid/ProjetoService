using Microsoft.EntityFrameworkCore;
using ProjetoService.Domain.Entities;
using ProjetoService.Infrastructure.Data.Mapps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoService.Infrastructure.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        private DbSet<Projeto> Projetos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            builder.ApplyConfiguration(new ProjetoMapp());

            base.OnModelCreating(builder);
        }
    }
}
