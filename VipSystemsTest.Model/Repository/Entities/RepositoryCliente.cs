using VipSystemsTest.Model.Data;
using VipSystemsTest.Model.Entities;
using VipSystemsTest.Model.IRepository.Entities;

namespace VipSystemsTest.Model.Repository.Entities
{
    public class RepositoryCliente : Repository<Cliente>, IRepositoryCliente
    {
        public RepositoryCliente(MovControlDbContext dbContext) : base(dbContext)
        {
        }

        public Cliente? GetByCPF(string CPF)
        {
            return dbContext.Clientes.Where(cliente => cliente.CPF == CPF).FirstOrDefault();
        }
    }
}