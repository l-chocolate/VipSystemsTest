
using System.Text;
using VipSystemsTest.Controller.Enum;
using VipSystemsTest.Model.Entities;
using VipSystemsTest.Model.IRepository.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VipSystemsTest.Controller
{
    public class ClienteController(IRepositoryCliente iRepositoryCliente)
    {
        private readonly IRepositoryCliente iRepositoryCliente = iRepositoryCliente;

        public Cliente? SearchByCPF(string CPF)
        {
            return iRepositoryCliente.GetByCPF(CPF);
        }

        public AccessValidationResult SecondLevelValidation(Cliente cliente, SecondLevelValidationType validationType, string answer)
        {
            Dictionary<SecondLevelValidationType, string> correctValues = new Dictionary<SecondLevelValidationType, string>()
            {
                { SecondLevelValidationType.MothersName, cliente.NomeDaMae },
                { SecondLevelValidationType.BirthDayAndYear, $"{cliente.DataDeNascimento.Day.ToString("00")}{cliente.DataDeNascimento.Year.ToString("0000")}" },
                { SecondLevelValidationType.BirthMonthAndYear, $"{cliente.DataDeNascimento.Month.ToString("00")}{cliente.DataDeNascimento.Year.ToString("0000")}" },
                { SecondLevelValidationType.BirthDayAndMonth, $"{cliente.DataDeNascimento.Day.ToString("00")}{cliente.DataDeNascimento.Month.ToString("00")}" }
            };
            bool isValid = correctValues[validationType] == answer;
            AccessValidationResult result = new AccessValidationResult()
            {
                Result = isValid,
                BlockReason = (isValid? null : BlockReason.ErroSegundoNivel)
            };
            return result;
        }

        public struct AccessValidationResult()
        {
            public bool Result { get; set; }
            public BlockReason? BlockReason { get; set; }
        }

        public AccessValidationResult ValidateAccessDayAndTime(Cliente cliente)
        {
            int dayOfWeek = ((int)DateTime.Now.DayOfWeek) + 1;
            if (cliente.DiasDeAcesso[dayOfWeek - 1] == '1')
            {
                if (DateTime.Now <= DateTime.Parse(cliente.HoraFinalDePermissaoDeAcesso) && DateTime.Now >= DateTime.Parse(cliente.HoraInicialDePermissaoDeAcesso))
                {
                    return new AccessValidationResult() { Result = true };
                }
                else
                {
                    return new AccessValidationResult() { Result = false, BlockReason = BlockReason.ForaDoHorario };
                }
            }
            else
            {
                return new AccessValidationResult() { Result = false, BlockReason = BlockReason.ForaDoDia };
            }
        }

        public AccessValidationResult ValidateClientPassword(Cliente? cliente, byte[] enteredPassword)
        {
            bool isValid = cliente?.Senha == TransformHashByteArrayIntoString(enteredPassword);
            AccessValidationResult result = new AccessValidationResult()
            {
                Result = isValid,
                BlockReason = (isValid ? null : BlockReason.SenhaInvalida)
            };
            return result;
        }
        static string TransformHashByteArrayIntoString(byte[] byteArray)
        {
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < byteArray.Length; i++)
            {
                sBuilder.Append(byteArray[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}