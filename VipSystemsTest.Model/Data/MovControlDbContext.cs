using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using VipSystemsTest.Model.Entities;
using VipSystemsTest.Model.Properties;

namespace VipSystemsTest.Model.Data
{
    public class MovControlDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }

        public MovControlDbContext(DbContextOptions<MovControlDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente()
                {
                    Id = 1,
                    CPF = "12345678910",
                    DiasDeAcesso = "0001000",
                    HoraFinalDePermissaoDeAcesso = "23:59:59",
                    HoraInicialDePermissaoDeAcesso = "00:00:00",
                    Nome = "Teste",
                    Senha = "698dc19d489c4e4db73e28a713eab07b",
                    DataDeNascimento = DateTime.Parse("1994-12-21"),
                    NomeDaMae = "NomeDaMaeTeste",
                    Foto = Resources.imagem1
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}