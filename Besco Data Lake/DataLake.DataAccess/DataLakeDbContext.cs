using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataLake.DataAccess
{
    public class DataLakeDbContext : DbContext
    {
        public DataLakeDbContext()
        {

        }
        public DataLakeDbContext(DbContextOptions<DataLakeDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}