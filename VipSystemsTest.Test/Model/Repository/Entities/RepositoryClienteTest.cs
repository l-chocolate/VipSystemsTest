using Microsoft.EntityFrameworkCore;
using System;
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
        public RepositoryClienteTest()
        {
            repositoryCliente = new RepositoryCliente(dbContext);
            InitializeTestData();
        }
        private void InitializeTestData()
        {
            dbContext.Clientes.Add(new Cliente() { 
                CPF = "12345678910", 
                DiasDeAcesso = "", 
                HoraFinalDePermissaoDeAcesso = "", 
                HoraInicialDePermissaoDeAcesso = "", 
                Nome = "Teste", 
                Senha = "teste" }
            );
            dbContext.SaveChanges();
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
