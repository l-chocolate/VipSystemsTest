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
                    DiasDeAcesso = "1111111",
                    HoraFinalDePermissaoDeAcesso = "23:59:59",
                    HoraInicialDePermissaoDeAcesso = "00:00:00",
                    Nome = "João",
                    Senha = CreateHashPassword("joão"),
                    DataDeNascimento = DateTime.Parse("1990-03-06"),
                    NomeDaMae = "Maria",
                    Foto = Resources.imagem1
                },
                new Cliente()
                {
                    Id = 2,
                    CPF = "98765432101",
                    DiasDeAcesso = "1110111",
                    HoraFinalDePermissaoDeAcesso = "23:59:59",
                    HoraInicialDePermissaoDeAcesso = "00:00:00",
                    Nome = "José",
                    Senha = CreateHashPassword("josé"),
                    DataDeNascimento = DateTime.Parse("1994-02-02"),
                    NomeDaMae = "Helena",
                    Foto = Resources.imagem2
                },
                new Cliente()
                {
                    Id = 3,
                    CPF = "11122233344",
                    DiasDeAcesso = "1111111",
                    HoraFinalDePermissaoDeAcesso = "14:00:00",
                    HoraInicialDePermissaoDeAcesso = "10:00:00",
                    Nome = "Carolina",
                    Senha = CreateHashPassword("CaRoLiNa"),
                    DataDeNascimento = DateTime.Parse("1998-06-01"),
                    NomeDaMae = "Luana",
                    Foto = Resources.imagem3
                },
                new Cliente()
                {
                    Id = 4,
                    CPF = "55566677788",
                    DiasDeAcesso = "1111111",
                    HoraFinalDePermissaoDeAcesso = "23:59:59",
                    HoraInicialDePermissaoDeAcesso = "00:00:00",
                    Nome = "Mário",
                    Senha = CreateHashPassword("mario"),
                    DataDeNascimento = DateTime.Parse("2000-10-25"),
                    NomeDaMae = "Laura"
                }
            );
            List<Movimento> failedLogins = new List<Movimento>();
            for (int contador = 0; contador <= 4; contador++)
            {
                failedLogins.Add(new Movimento { Id = contador + 1, IdDoCliente = 4, IdDeStatus = -1, DataEHoraDeEntrada = DateTime.Now, ObservacaoDeAcesso = $"Login errado para teste número {contador}" });
            }
            modelBuilder.Entity<Movimento>().HasData(
                failedLogins);
            base.OnModelCreating(modelBuilder);
        }
        static string CreateHashPassword(string password)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] hashByteArray = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < hashByteArray.Length; i++)
            {
                sBuilder.Append(hashByteArray[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}