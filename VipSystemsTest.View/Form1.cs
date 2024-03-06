using Microsoft.Extensions.DependencyInjection;
using VipSystemsTest.Controller;
using VipSystemsTest.Controller.Entities;
using VipSystemsTest.Controller.Enum;
using VipSystemsTest.Model.Entities;
using VipSystemsTest.Model.IRepository.Entities;

namespace VipSystemsTest.View
{
    public partial class Form1 : Form
    {
        ClienteController clienteController;
        MovimentoController movimentoController;
        Cliente? cliente;
        Dictionary<Cliente, int> clientInvalidLogins = new Dictionary<Cliente, int>();
        SecondLevelValidationType secondLevelValidationType;
        IServiceProvider _serviceProvider;
        public Form1(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            clienteController = new ClienteController(serviceProvider.GetRequiredService<IRepositoryCliente>());
            movimentoController = new MovimentoController(serviceProvider.GetRequiredService<IRepositoryMovimento>());
        }

        private void bt_CPF_Click(object sender, EventArgs e)
        {
            cliente = clienteController.SearchByCPF(tb_CPF.Text);
            if (cliente != null)
            {
                if (!movimentoController.IsUserBlocked(cliente))
                {
                    ClienteController.AccessValidationResult result = clienteController.ValidateAccessDayAndTime(cliente);
                    if (!result.Result)
                    {
                        movimentoController.AddMovimento(CreateMovimentoObject(cliente, result));
                        MessageBox.Show(ReturnBlockReasonText(result.BlockReason.Value), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        clientInvalidLogins.Add(cliente, 0);
                        panel_senha.Visible = true;
                        panel_CPF.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Cliente bloqueado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Cliente não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_password_Click(object sender, EventArgs e)
        {
            if (clientInvalidLogins[cliente] == 5)
            {
                MessageBox.Show($"Cliente bloqueado por inúmeras tentativas de login incorreto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ClienteController.AccessValidationResult result = clienteController.ValidateClientPassword(cliente, tb_password.Text);
                if (result.Result)
                {
                    panel_senha.Enabled = false;
                    secondLevelValidationType = (SecondLevelValidationType)Enum.ToObject(typeof(SecondLevelValidationType), RandomNumber());
                    lb_secondLevel.Text = ReturnSecondValidationText(secondLevelValidationType);
                    panel_secondValidation.Visible = true;
                }
                else
                {
                    clientInvalidLogins[cliente]++;
                    movimentoController.AddMovimento(CreateMovimentoObject(cliente, result));
                    MessageBox.Show($"Senha incorreta{ReturnWarningAboutLogin()}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Movimento CreateMovimentoObject(Cliente cliente, ClienteController.AccessValidationResult result)
        {
            return new Movimento()
            {
                IdDoCliente = cliente.Id,
                IdDeStatus = result.Result ? 1 : -1,
                Local = Environment.MachineName,
                MotivoDoBloqueio = result.Result ? "" : ReturnBlockReasonText(result.BlockReason.Value)
            };
        }

        private string ReturnBlockReasonText(BlockReason blockReason)
        {
            Dictionary<BlockReason, string> blockReasons = new Dictionary<BlockReason, string>()
            {
                { BlockReason.SenhaInvalida, "SENHA INVÁLIDA" },
                { BlockReason.ErroSegundoNivel, "ERROU SEGNDO NÍVEL DE AUTENTICAÇÃO" },
                { BlockReason.ForaDoHorario, "ACESSO FORA DE HORÁRIO PERMITIDO" },
                { BlockReason.ForaDoDia, "ACESSO FORA DO DIA PERMITIDO" }
            };
            return blockReasons[blockReason];
        }

        private string ReturnSecondValidationText(SecondLevelValidationType validationType)
        {
            Dictionary<SecondLevelValidationType, string> validationTexts = new Dictionary<SecondLevelValidationType, string>()
            {
                { SecondLevelValidationType.MothersName, "Digite o nome da mãe" },
                { SecondLevelValidationType.BirthDayAndYear, "Digite o dia e ano de nascimento (6 dígitos). Ex: 21/12/1994 = 211994" },
                { SecondLevelValidationType.BirthDayAndMonth, "Digite o dia e mês de nascimento (4 dígitos). Ex: 21/12/1994 = 2112" },
                { SecondLevelValidationType.BirthMonthAndYear, "Digite o mês e ano de nascimento (6 dígitos). Ex: 21/12/1994 = 121994" }
            };
            return validationTexts[validationType];
        }
        public static int RandomNumber()
        {
            Random random = new Random();
            return random.Next(0, 4);
        }

        private void bt_secondLevel_Click(object sender, EventArgs e)
        {
            if (clientInvalidLogins[cliente] == 5)
            {
                MessageBox.Show($"Cliente bloqueado por inúmeras tentativas de login incorreto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ClienteController.AccessValidationResult result = clienteController.SecondLevelValidation(cliente, secondLevelValidationType, tb_secondLevel.Text);
                Movimento movimento = movimentoController.AddMovimento(CreateMovimentoObject(cliente, result));
                if (!result.Result)
                {
                    clientInvalidLogins[cliente]++;
                    MessageBox.Show($"Resposta incorreta{ReturnWarningAboutLogin()}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Login realizado com sucesso", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new Form2(_serviceProvider, cliente, DateTime.Now, movimento).Show();
                }
            }
        }
        private string ReturnWarningAboutLogin()
        {
            if (clientInvalidLogins[cliente] == 5)
            {
                return " - Usuário bloqueado";
            }
            else if (clientInvalidLogins[cliente] >= 3)
            {
                return $" - Cuidado, você tem mais {5 - clientInvalidLogins[cliente]} tentativas";
            }
            else
            {
                return "";
            }
        }
    }
}
