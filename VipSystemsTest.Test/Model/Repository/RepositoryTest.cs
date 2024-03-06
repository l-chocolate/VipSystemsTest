using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VipSystemsTest.Model.Data;
using VipSystemsTest.Test.Model.Data;

namespace VipSystemsTest.Test.Model.Repository
{
    public abstract class RepositoryTest
    {
        public  MovControlDbContext dbContext;
        public RepositoryTest()
        {
            MovControlDbContextTest dbContextTest = new MovControlDbContextTest();
            dbContext = dbContextTest.CreateTestDbContext();
            InitializeTestData();
        }
        public abstract void InitializeTestData();
    }
}
