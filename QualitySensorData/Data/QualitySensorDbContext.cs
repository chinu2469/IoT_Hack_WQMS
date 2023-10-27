using QualitySensorData.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace QualitySensorData.Data
{
    public class QualitySensorDbContext : DbContext
    {
        public QualitySensorDbContext(DbContextOptions<QualitySensorDbContext> options) : base(options)
        {

        }

        public DbSet<QualitySensorDataMdl> QualitySensorDataTable { get; set; }
        //public DbSet<Users> Users { get; set; }
        //public DbSet<DeviceErrors> deviceErrors { get; set; }
    }
}
