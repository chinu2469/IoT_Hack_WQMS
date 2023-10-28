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
        public DbSet<ConsumptionStat> ConsumptionData { get; set; }
        public DbSet<FloorConsumptionStat> floorWiseConsumptionData { get; set; }

        public DbSet<MainTankStat> MainTankdata { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
