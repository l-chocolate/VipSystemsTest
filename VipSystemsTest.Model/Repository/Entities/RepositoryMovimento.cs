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
    }
}