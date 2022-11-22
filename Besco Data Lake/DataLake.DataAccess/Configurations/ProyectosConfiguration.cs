
using DataLake.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLake.DataAccess.Configurations
{
    public class ProyectosConfiguration : IEntityTypeConfiguration<Proyectos>
    {
        public void Configure(EntityTypeBuilder<Proyectos> builder)
        {
            builder.HasQueryFilter(p => p.IdProyecto > 0);
        }
    }
}
