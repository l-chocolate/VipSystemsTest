using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
            Cliente? cliente = repositoryClienteTest.clienteUsedForTest;
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] enteredPassword = md5.ComputeHash(Encoding.UTF8.GetBytes("teste"));
            byte[] wrongPassword = md5.ComputeHash(Encoding.UTF8.GetBytes("TeSTe"));
            ClienteController.AccessValidationResult passwordResult = clienteController.ValidateClientPassword(cliente, enteredPassword);
            ClienteController.AccessValidationResult wrongPasswordResult = clienteController.ValidateClientPassword(cliente, wrongPassword);
            Assert.IsTrue(passwordResult.Result);
            Assert.IsTrue(wrongPasswordResult.Result == false && wrongPasswordResult.BlockReason == VipSystemsTest.Controller.Enum.BlockReason.SenhaInvalida);
        }
        [Test]
        public void Test_SecondLevelValidation()
        {
            Cliente? cliente = repositoryClienteTest.clienteUsedForTest;
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
                    ClienteController.AccessValidationResult result = clienteController.SecondLevelValidation(cliente, validationType, secondLevelValidationAnswer[validationType]);
                    Assert.IsTrue(result.Result);
                }
                ClienteController.AccessValidationResult wrongResult = clienteController.SecondLevelValidation(cliente, SecondLevelValidationType.MothersName, "NomeDaMaeTesteErro");
                Assert.IsTrue(wrongResult.Result == false && wrongResult.BlockReason == VipSystemsTest.Controller.Enum.BlockReason.ErroSegundoNivel);
            }
        }
        [Test]
        public void Test_ValidateAccessDayAndTime()
        {
            Cliente? cliente = repositoryClienteTest.clienteUsedForTest;
            Cliente? clientWithNoAccessDay = repositoryClienteTest.clientWithNoAccessDay;
            Cliente? clientWithNoAccessTime = repositoryClienteTest.clientWithNoAccessTime;
            if (cliente != null)
            {
                ClienteController.AccessValidationResult Result = clienteController.ValidateAccessDayAndTime(cliente);
                Assert.IsTrue(Result.Result == true);
            }
            if (clientWithNoAccessDay != null)
            {
                ClienteController.AccessValidationResult Result = clienteController.ValidateAccessDayAndTime(clientWithNoAccessDay);
                Assert.IsTrue(Result.Result == false && Result.BlockReason == VipSystemsTest.Controller.Enum.BlockReason.ForaDoDia);
            }
            if (clientWithNoAccessTime != null)
            {
                ClienteController.AccessValidationResult Result = clienteController.ValidateAccessDayAndTime(clientWithNoAccessTime);
                Assert.IsTrue(Result.Result == false && Result.BlockReason == VipSystemsTest.Controller.Enum.BlockReason.ForaDoHorario);
            }
        }
    }
}
