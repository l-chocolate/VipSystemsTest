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
                movimentoController.AddMovimento(repositoryMovimentoTest.movimentoUsedForTest);
        }
    }
}
