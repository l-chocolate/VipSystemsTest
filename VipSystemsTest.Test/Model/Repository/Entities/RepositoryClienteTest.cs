using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VipSystemsTest.Model;
using VipSystemsTest.Model.Data;
using VipSystemsTest.Model.Entities;
using VipSystemsTest.Model.Repository.Entities;

namespace VipSystemsTest.Test.Model.Repository.Entities
{
    public class RepositoryClienteTest : RepositoryTest
    {
        public RepositoryCliente repositoryCliente;
        public Cliente clienteUsedForTest = new Cliente()
        {
            Id = 1,
            CPF = "12345678910",
            DiasDeAcesso = CreateValidAccessDay(DateTime.Now),
            HoraFinalDePermissaoDeAcesso = "23:59:59",
            HoraInicialDePermissaoDeAcesso = "00:00:00",
            Nome = "Teste",
            Senha = CreateHashPassword("teste"),
            DataDeNascimento = DateTime.Parse("1994-12-21"),
            NomeDaMae = "NomeDaMaeTeste"
        };
        public Cliente blockedClient = new Cliente()
        {
            Id = 2,
            CPF = "09876543210",
            DiasDeAcesso = "",
            HoraFinalDePermissaoDeAcesso = "",
            HoraInicialDePermissaoDeAcesso = "",
            Nome = "Bloqueado",
            Senha = CreateHashPassword("bloqueado"),
            DataDeNascimento = DateTime.Parse("2000-01-01"),
            NomeDaMae = "NomeDaMaeTeste2"
        };
        public Cliente clientWithNoAccessDay = new Cliente()
        {
            Id = 3,
            CPF = "11133344456",
            DiasDeAcesso = CreateValidAccessDay(DateTime.Now.AddDays(4)),
            HoraFinalDePermissaoDeAcesso = "",
            HoraInicialDePermissaoDeAcesso = "",
            Nome = "SemDia",
            Senha = CreateHashPassword("SemDia"),
            DataDeNascimento = DateTime.Parse("2000-01-01"),
            NomeDaMae = "NomeDaMaeTeste3"
        };
        public Cliente clientWithNoAccessTime = new Cliente()
        {
            Id = 4,
            CPF = "11133344457",
            DiasDeAcesso = CreateValidAccessDay(DateTime.Now),
            HoraFinalDePermissaoDeAcesso = DateTime.Now.AddMinutes(-5).ToShortTimeString(),
            HoraInicialDePermissaoDeAcesso = "00:00:00",
            Nome = "SemHora",
            Senha = CreateHashPassword("SemHora"),
            DataDeNascimento = DateTime.Parse("2000-01-01"),
            NomeDaMae = "NomeDaMaeTeste4"
        };
        static string CreateValidAccessDay(DateTime dateTime)
        {
            string? result = "";
            for (int weekDay = 1; weekDay <= 7; weekDay++)
            {
                result = result + $"{((((int)dateTime.DayOfWeek) + 1) == weekDay ? "1" : "0")}";
            }
            return result;
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
        public RepositoryClienteTest()
        {
            repositoryCliente = new RepositoryCliente(dbContext);
        }
        public override void InitializeTestData()
        {
            if (dbContext.Clientes.Count() == 0)
            {
                dbContext.Clientes.Add(clienteUsedForTest);
                dbContext.Clientes.Add(blockedClient);
                dbContext.SaveChanges();
            }
        }
        [Test]
        public void Test_GetClientByCPF()
        { 
            Cliente? cliente1 = repositoryCliente.GetByCPF("12345678910");
            Cliente? cliente2 = repositoryCliente.GetByCPF("12345678911");
            Assert.IsNotNull(cliente1);
            Assert.IsNull(cliente2);
        }
    }
}
