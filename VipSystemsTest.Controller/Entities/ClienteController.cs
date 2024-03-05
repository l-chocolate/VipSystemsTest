
using VipSystemsTest.Model.Entities;
using VipSystemsTest.Model.IRepository.Entities;

namespace VipSystemsTest.Controller
{
    public class ClienteController(IRepositoryCliente iRepositoryCliente)
    {
        private readonly IRepositoryCliente iRepositoryCliente = iRepositoryCliente;

        public Cliente? SearchByCPF(string CPF)
        {
            return iRepositoryCliente.GetByCPF(CPF);
        }

        public bool ValidateClientPassword(Cliente? cliente, string enteredPassword)
        {
            return cliente.Senha == enteredPassword;
        }
    }
}