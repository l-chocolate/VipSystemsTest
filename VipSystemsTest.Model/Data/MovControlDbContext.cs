using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VipSystemsTest.Model.Entities;

namespace VipSystemsTest.Model.Data
{
    internal class MovControlDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }

        public MovControlDbContext(DbContextOptions<MovControlDbContext> options) : base(options)
        {
        }
    }
}