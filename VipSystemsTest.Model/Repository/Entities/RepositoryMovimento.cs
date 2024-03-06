using VipSystemsTest.Model.Data;
using VipSystemsTest.Model.Entities;
using VipSystemsTest.Model.IRepository.Entities;
using VipSystemsTest.Model.Repository;

namespace VipSystemsTest.Model
{
    public class RepositoryMovimento : Repository<Movimento>, IRepositoryMovimento
    {
        public RepositoryMovimento(MovControlDbContext dbContext) : base(dbContext)
        {
        }

        public List<Movimento> GetAllClientLogins(Cliente cliente)
        {
            return dbContext.Movimentos.Where(movimento => movimento.IdDoCliente == cliente.Id).ToList();
        }
    }
}