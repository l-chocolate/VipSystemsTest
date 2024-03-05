using Microsoft.EntityFrameworkCore;
using VipSystemsTest.Model.Data;
using VipSystemsTest.Model.Entities;
namespace VipSystemsTest.Test.Model.Data
{
    public class MovControlDbContextTest
    {
        public MovControlDbContext CreateTestDbContext()
        {
            var options = new DbContextOptionsBuilder<MovControlDbContext>()
                .UseInMemoryDatabase("MemoryMovControlDb")
                .Options;
            return new MovControlDbContext(options);
        }
        [Test]
        public void Test_DbContextConfiguration()
        {
            Assert.NotNull(CreateTestDbContext());
        }
    }
}