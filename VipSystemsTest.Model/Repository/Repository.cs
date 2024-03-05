using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VipSystemsTest.Model.Data;
using VipSystemsTest.Model.IRepository;

namespace VipSystemsTest.Model.Repository
{
    public class Repository<TEntidade>(MovControlDbContext dbContext) : IRepository<TEntidade> where TEntidade : class
    {
        public MovControlDbContext dbContext = dbContext;
    }
}
