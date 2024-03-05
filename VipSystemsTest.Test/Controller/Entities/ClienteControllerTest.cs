﻿using System;
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
        const string CPFUsedForTest = "12345678910";
        ClienteController clienteController;
        public ClienteControllerTest()
        {
            RepositoryClienteTest repositoryClienteTest = new RepositoryClienteTest();
            clienteController = new ClienteController(repositoryClienteTest.repositoryCliente);
        }
        [Test]
        public void Test_SearchByCPF()
        {
            Cliente? cliente = clienteController.SearchByCPF(CPFUsedForTest);
            Assert.IsNotNull(cliente);
        }
        [Test]
        public void Test_ValidateClientPassword()
        {
            Cliente? cliente = clienteController.SearchByCPF(CPFUsedForTest);
            string enteredPassword = "teste";
            string wrongPassword = "teste1";
            bool passwordResult = clienteController.ValidateClientPassword(cliente, enteredPassword);
            bool wrongPasswordResult = clienteController.ValidateClientPassword(cliente, wrongPassword);
            Assert.IsTrue(passwordResult);
            Assert.IsFalse(wrongPasswordResult);
        }
    }
}