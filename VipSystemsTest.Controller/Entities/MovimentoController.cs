using VipSystemsTest.Model.Entities;
using VipSystemsTest.Model.IRepository.Entities;

namespace VipSystemsTest.Controller.Entities
{
    public class MovimentoController(IRepositoryMovimento iRepositoryMovimento)
    {
        private readonly IRepositoryMovimento iRepositoryMovimento = iRepositoryMovimento;

        public void Edit(Movimento movimento, Cliente cliente)
        {
            if (movimento.DataEHoraDeSaida != null && movimento.DataEHoraDeSaida >= DateTime.Parse(cliente.HoraFinalDePermissaoDeAcesso))
                movimento.ObservacaoDeAcesso = "SAÍDA FORA DO HORÁRIO PERMITIDO.";
            iRepositoryMovimento.Update(movimento, movimento.Id);
        }

        public Movimento AddMovimento(Movimento movimentoUsedForTest)
        {
            return iRepositoryMovimento.Add(movimentoUsedForTest);
        }

        public List<Movimento> GetAllClientLogins(Cliente cliente)
        {
            return iRepositoryMovimento.GetAllClientLogins(cliente);
        }

        public bool IsUserBlocked(Cliente cliente)
        {
            List<Movimento> movimentos = iRepositoryMovimento.GetAllClientLogins(cliente);
            List<Movimento> lastFiveLogins = movimentos.OrderBy(movimento => movimento.Id).TakeLast(5).ToList();
            return !(lastFiveLogins.Count() < 5 || lastFiveLogins.Count(movimento => movimento.IdDeStatus == 1) > 0);
        }
    }
}