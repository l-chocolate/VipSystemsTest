using VipSystemsTest.Model.Entities;
using VipSystemsTest.Model.Repository.Entities;
using VipSystemsTest.Test.Model.Repository;
using VipSystemsTest.Test.Model.Repository.Entities;

namespace VipSystemsTest.Test
{
    public class RepositoryMovimentoTest : RepositoryTest
    {
        public RepositoryMovimento repositoryMovimento;
        public Movimento? movimentoUsedForTest;
        public Cliente? blockedClient;
        public Cliente? clientUsedForTest;
        public RepositoryMovimentoTest()
        {
            repositoryMovimento = new RepositoryMovimento(dbContext);
        }
        public override void InitializeTestData()
        {
            RepositoryClienteTest repositoryClienteTest = new RepositoryClienteTest();
            clientUsedForTest = repositoryClienteTest.clienteUsedForTest;
            movimentoUsedForTest = new Movimento()
            {
                IdDoCliente = clientUsedForTest.Id,
                DataEHoraDeEntrada = DateTime.Now,
                IdDeStatus = 1,
                Local = Environment.MachineName
            };
            dbContext.Movimentos.Add(movimentoUsedForTest);
            blockedClient = repositoryClienteTest.blockedClient;
            for (int contador = 0; contador <= 4; contador++)
            {
                dbContext.Movimentos.Add(new Movimento { IdDoCliente = blockedClient.Id, IdDeStatus = -1, DataEHoraDeEntrada = DateTime.Now, ObservacaoDeAcesso = $"Login errado para teste número {contador}" });
            }
            dbContext.SaveChanges();
        }
    }
}