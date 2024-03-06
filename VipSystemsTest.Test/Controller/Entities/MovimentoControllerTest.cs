using VipSystemsTest.Controller.Entities;
using VipSystemsTest.Model.Entities;
using VipSystemsTest.Test.Model.Repository.Entities;

namespace VipSystemsTest.Test.Controller.Entities
{
    public class MovimentoControllerTest
    {
        MovimentoController movimentoController;
        RepositoryMovimentoTest repositoryMovimentoTest;
        public MovimentoControllerTest()
        {
            repositoryMovimentoTest = new RepositoryMovimentoTest();
            movimentoController = new MovimentoController(repositoryMovimentoTest.repositoryMovimento);
        }
        [Test]
        public void Test_AddMovimento()
        {
            if (repositoryMovimentoTest.movimentoUsedForTest != null)
            {
                repositoryMovimentoTest.movimentoUsedForTest.Id = 1000;
                movimentoController.AddMovimento(repositoryMovimentoTest.movimentoUsedForTest);
            }
        }
        [Test]
        public void Test_IsUserBlocked()
        {
            if (repositoryMovimentoTest.blockedClient != null)
                Assert.IsTrue(movimentoController.IsUserBlocked(repositoryMovimentoTest.blockedClient));
            if (repositoryMovimentoTest.clientUsedForTest != null)
                Assert.IsFalse(movimentoController.IsUserBlocked(repositoryMovimentoTest.clientUsedForTest));
        }
        [Test]
        public void Test_AddExit()
        {
            if (repositoryMovimentoTest.movimentoUsedForTest != null && repositoryMovimentoTest.clientUsedForTest != null)
            {
                repositoryMovimentoTest.clientUsedForTest.HoraFinalDePermissaoDeAcesso = DateTime.Now.AddMinutes(-30).ToShortTimeString();
                movimentoController.Edit(repositoryMovimentoTest.movimentoUsedForTest, repositoryMovimentoTest.clientUsedForTest);
            }
        }
        [Test]
        public void Test_GetAllClientLogins()
        {
            if (repositoryMovimentoTest.clientUsedForTest != null)
                Assert.IsTrue(movimentoController.GetAllClientLogins(repositoryMovimentoTest.clientUsedForTest).Count() > 0);
        }
    }
}
