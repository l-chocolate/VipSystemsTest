using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VipSystemsTest.Controller.Entities;
using VipSystemsTest.Controller;
using VipSystemsTest.Model.Entities;
using VipSystemsTest.Model.IRepository.Entities;

namespace VipSystemsTest.View
{
    public partial class Form2 : Form
    {
        Cliente cliente;
        DateTime loginDateTime;
        ClienteController clienteController;
        MovimentoController movimentoController;
        Movimento currentMovimento;
        public Form2(IServiceProvider serviceProvider, Cliente cliente, DateTime loginDateTime, Movimento movimento)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.loginDateTime = loginDateTime;
            this.currentMovimento = movimento;
            clienteController = new ClienteController(serviceProvider.GetRequiredService<IRepositoryCliente>());
            movimentoController = new MovimentoController(serviceProvider.GetRequiredService<IRepositoryMovimento>());
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            bool nenhumaEntrada = false;
            List<Movimento> movimentos = movimentoController.GetAllClientLogins(cliente);
            lb_ClientName.Text = cliente.Nome;
            lb_AccessDateAndTime.Text = $"Data e horário de login: {loginDateTime.ToString()}";
            Movimento lastEntrada = movimentos.LastOrDefault(movimento => movimento != currentMovimento && movimento.DataEHoraDeEntrada != null);
            Movimento lastSaida = movimentos.LastOrDefault(movimento => movimento != currentMovimento && movimento.DataEHoraDeSaida != null);
            if (cliente.Foto != null)
            {
                MemoryStream mStream = new MemoryStream();
                byte[] pData = cliente.Foto;
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                Bitmap bm = new Bitmap(mStream, false);
                mStream.Dispose();
                pb_userPicture.Image = bm;
            }
            if (lastEntrada != null && lastEntrada.DataEHoraDeEntrada != null)
            {
                lb_LastEntryDateAndTime.Text = $"Ultima entrada: {lastEntrada.DataEHoraDeEntrada.Value.ToString()}";
            }
            else
            {
                lb_LastEntryDateAndTime.Text = "Nenhuma entrada registrada até agora";
                nenhumaEntrada = true;
            }
            if (lastSaida != null && lastSaida.DataEHoraDeSaida != null)
            {
                lb_LastExitDateAndTime.Text = $"Ultima saída: {lastSaida.DataEHoraDeSaida.Value.ToString()}";
            }
            else
            {
                lb_LastExitDateAndTime.Text = "Nenhuma saída registrada até agora";
            }
            lb_NumberOfAccesses.Text = $"Entradas esse mês: {(nenhumaEntrada ? "0" : movimentos.Where(movimento => movimento.DataEHoraDeEntrada != null).Count(movimento => movimento.DataEHoraDeEntrada.Value.Month == DateTime.Now.Month))}";
        }

        private void bt_Confirm_Click(object sender, EventArgs e)
        {
            if (cb_MovType.SelectedItem == null)
            {
                MessageBox.Show("Selecione entrada ou saída", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cb_MovType.SelectedItem.ToString() == "Entrada")
                {
                    currentMovimento.DataEHoraDeEntrada = DateTime.Now;
                }
                else
                {
                    currentMovimento.DataEHoraDeSaida = DateTime.Now;
                }
                movimentoController.Edit(currentMovimento, cliente);
                MessageBox.Show($"{cb_MovType.SelectedItem.ToString()} registrada!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }
}
