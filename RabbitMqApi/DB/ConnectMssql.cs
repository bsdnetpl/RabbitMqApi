using Microsoft.EntityFrameworkCore;
using RabbitMqApi.DTO;

namespace RabbitMqApi.DB
{
    public class ConnectMssql : DbContext
    {
        public ConnectMssql(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
