using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VipSystemsTest.Controller;
using VipSystemsTest.Model.Entities;
using VipSystemsTest.Test.Model.Repository.Entities;

namespace VipSystemsTest.Test.Controller.Entities
{
    public class ClienteControllerTest
    {
        RepositoryClienteTest repositoryClienteTest;
        ClienteController clienteController;
        public ClienteControllerTest()
        {
            repositoryClienteTest = new RepositoryClienteTest();
            clienteController = new ClienteController(repositoryClienteTest.repositoryCliente);
        }
        [Test]
        public void Test_SearchByCPF()
        {
            Cliente? cliente = clienteController.SearchByCPF(repositoryClienteTest.clienteUsedForTest.CPF);
            Assert.IsNotNull(cliente);
        }
        [Test]
        public void Test_ValidateClientPassword()
        {
            Cliente? cliente = clienteController.SearchByCPF(repositoryClienteTest.clienteUsedForTest.CPF);
            string enteredPassword = "teste";
            string wrongPassword = "teste1";
            bool passwordResult = clienteController.ValidateClientPassword(cliente, enteredPassword);
            bool wrongPasswordResult = clienteController.ValidateClientPassword(cliente, wrongPassword);
            Assert.IsTrue(passwordResult);
            Assert.IsFalse(wrongPasswordResult);
        }
        [Test]
        public void Test_SecondLevelValidation()
        {
            Cliente? cliente = clienteController.SearchByCPF(repositoryClienteTest.clienteUsedForTest.CPF);
            if (cliente != null)
            {
                Dictionary<SecondLevelValidationType, string> secondLevelValidationAnswer = new Dictionary<SecondLevelValidationType, string>()
            {
                { SecondLevelValidationType.MothersName, "NomeDaMaeTeste" },
                { SecondLevelValidationType.BirthDayAndYear, "211994" },
                { SecondLevelValidationType.BirthMonthAndYear, "121994" },
                { SecondLevelValidationType.BirthDayAndMonth, "2112" }
            };
                for (int validationId = 0; validationId <= 3; validationId++)
                {
                    SecondLevelValidationType validationType = secondLevelValidationAnswer.Keys.ElementAt(validationId);
                    Assert.IsTrue(clienteController.SecondLevelValidation(cliente, validationType, secondLevelValidationAnswer[validationType]));
                }
            }
        }
    }
}
