using Microsoft.EntityFrameworkCore;
using VipSystemsTest.Model.Data;
using VipSystemsTest.Model.Entities;
namespace VipSystemsTest.Test.Data
{
    public class MovControlDbContextTest
    {
        [Test]
        public void Test_DbContextConfiguration()
        {
            var options = new DbContextOptionsBuilder<MovControlDbContext>()
                .UseInMemoryDatabase("MemoryMovControlDb")
                .Options;
            var context = new MovControlDbContext(options);
            Assert.NotNull(context);
        }
    }
}