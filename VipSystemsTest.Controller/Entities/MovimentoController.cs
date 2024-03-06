using VipSystemsTest.Model.Entities;
using VipSystemsTest.Model.IRepository.Entities;

namespace VipSystemsTest.Controller.Entities
{
    public class MovimentoController(IRepositoryMovimento iRepositoryMovimento)
    {
        private readonly IRepositoryMovimento iRepositoryMovimento = iRepositoryMovimento;

        public void AddMovimento(Movimento movimentoUsedForTest)
        {
            iRepositoryMovimento.Add(movimentoUsedForTest);
        }
    }
}