using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Configuracoes
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        {
        }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // verifica se tem string configurada com o banco no startap e coloca a srtring pra ca e configura 
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Produto>().ToTable("Produto").HasKey(t => t.CodigoProduto);

            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            string stringconexao = "Data Source=00.000.000.000;Initial Catalog=DESAFIO;Integrated Security=False;User ID=SA;Password=123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            return stringconexao;
        }








    }
}
