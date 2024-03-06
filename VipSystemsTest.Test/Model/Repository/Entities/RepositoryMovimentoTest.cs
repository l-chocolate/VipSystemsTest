using VipSystemsTest.Model;
using VipSystemsTest.Model.Entities;
using VipSystemsTest.Test.Model.Repository;
using VipSystemsTest.Test.Model.Repository.Entities;

namespace VipSystemsTest.Test
{
    public class RepositoryMovimentoTest : RepositoryTest
    {
        public RepositoryMovimento repositoryMovimento;
        public Movimento? movimentoUsedForTest;
        public RepositoryMovimentoTest()
        {
            repositoryMovimento = new RepositoryMovimento(dbContext);
        }

        public override void InitializeTestData()
        {
            RepositoryClienteTest repositoryClienteTest = new RepositoryClienteTest();
            movimentoUsedForTest = new Movimento()
            {
                IdDoCliente = repositoryClienteTest.clienteUsedForTest.Id,
                DataEHoraDeEntrada = DateTime.Now,
                IdDeStatus = 1,
                Local = Environment.MachineName
            };
        }
    }
}