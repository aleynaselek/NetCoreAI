using Microsoft.EntityFrameworkCore;
using NetCoreAI.Project1_ApiDemo.Enitities;

namespace NetCoreAI.Project1_ApiDemo.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-OTC2IOU\\SQLEXPRESS;Initial Catalog=ApiAIDB;Integrated Security=True;TrustServerCertificate=True;");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
