
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

        public bool SecondLevelValidation(Cliente cliente, SecondLevelValidationType validationType, string answer)
        {
            Dictionary<SecondLevelValidationType, string> correctValues = new Dictionary<SecondLevelValidationType, string>()
            {
                { SecondLevelValidationType.MothersName, cliente.NomeDaMae },
                { SecondLevelValidationType.BirthDayAndYear, $"{cliente.DataDeNascimento.Day.ToString("00")}{cliente.DataDeNascimento.Year.ToString("0000")}" },
                { SecondLevelValidationType.BirthMonthAndYear, $"{cliente.DataDeNascimento.Month.ToString("00")}{cliente.DataDeNascimento.Year.ToString("0000")}" },
                { SecondLevelValidationType.BirthDayAndMonth, $"{cliente.DataDeNascimento.Day.ToString("00")}{cliente.DataDeNascimento.Month.ToString("00")}" }
            };
            return correctValues[validationType] == answer;
        }

        public bool ValidateClientPassword(Cliente? cliente, string enteredPassword)
        {
            return cliente?.Senha == enteredPassword;
        }
    }
}