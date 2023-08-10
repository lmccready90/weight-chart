using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WeightLog> WeightLog { get; set; }
        public DbSet<Unit> Unit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeightLog>()
                .ToTable("WeightLog");            
            modelBuilder.Entity<WeightLog>()
                .Property(p => p.Date)
                .HasColumnType("datetime");
            modelBuilder.Entity<WeightLog>()
                .Property(p => p.Weight)
                .HasColumnType("decimal(5,2)");
                
            modelBuilder.Entity<WeightLog>()
                .HasData(
                    new WeightLog
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.UtcNow.AddMonths(-5),
                        Weight = 220,
                        Unit = (int)Domain.Unit.Units.lb
                    },
                    new WeightLog
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.UtcNow.AddMonths(-4),
                        Weight = 216,
                        Unit = (int)Domain.Unit.Units.lb
                    },
                    new WeightLog
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.UtcNow.AddMonths(-3),
                        Weight = 212,
                        Unit = (int)Domain.Unit.Units.lb
                    },
                    new WeightLog
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.UtcNow.AddMonths(-2),
                        Weight = 208,
                        Unit = (int)Domain.Unit.Units.lb
                    },
                    new WeightLog
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.UtcNow.AddMonths(-1),
                        Weight = 204,
                        Unit = (int)Domain.Unit.Units.lb
                    },
                    new WeightLog
                    {
                        Id = Guid.NewGuid(),
                        Date = DateTime.UtcNow.Date,
                        Weight = 200,
                        Unit = (int)Domain.Unit.Units.lb
                    }
                );
            modelBuilder.Entity<Unit>() 
                .ToTable("Unit");
            modelBuilder.Entity<Unit>() 
                .Property(p => p.Symbol)
                .HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Unit>() 
                .Property(p => p.Description)
                .HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Unit>()
                .HasData(
                    new Unit
                    {
                        Id = (int)Domain.Unit.Units.lb,
                        Symbol = "lb",
                        Description = "Pounds"
                    },
                    new Unit
                    {
                        Id = (int)Domain.Unit.Units.kg,
                        Symbol = "kg",
                        Description = "Kilograms"
                    },
                    new Unit
                    {
                        Id = (int)Domain.Unit.Units.st,
                        Symbol = "st",
                        Description = "Stone"
                    }                    
                );
        }
    }
}
