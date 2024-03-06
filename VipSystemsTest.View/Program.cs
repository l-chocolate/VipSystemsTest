using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using VipSystemsTest.Model;
using VipSystemsTest.Model.Data;
using VipSystemsTest.Model.Entities;
using VipSystemsTest.Model.IRepository.Entities;
using VipSystemsTest.Model.Repository.Entities;

namespace VipSystemsTest.View
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //using (MovControlDbContext db = new MovControlDbContext(new DbContextOptionsBuilder<MovControlDbContext>().UseSqlServer(connectionString.ToString()).Options))
            //{
            //    db.Database.EnsureCreated();
            //}
            var serviceProvider = ConfigureServices();
            Application.Run(serviceProvider.GetRequiredService<Form1>());
        }
        static IServiceProvider ConfigureServices()
        {
            var connectionString = new SqlConnectionStringBuilder
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                InitialCatalog = "MovControlDb",
                IntegratedSecurity = true
            };
            var services = new ServiceCollection();

            services.AddDbContext<MovControlDbContext>(
                options => options.UseSqlServer(connectionString.ToString()));

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<MovControlDbContext>();
                db.Database.EnsureCreated();
            }

            services.AddTransient<IRepositoryCliente, RepositoryCliente>();
            services.AddTransient<IRepositoryMovimento, RepositoryMovimento>();
            services.AddTransient<Form1>();
            return services.BuildServiceProvider();
        }
    }
}