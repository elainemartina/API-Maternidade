using Microsoft.EntityFrameworkCore;
using MaternidadeAPI.Models;

namespace MaternidadeAPI.Data
{
    public class DataContext : DbContext
    {
            public DataContext(DbContextOptions<DataContext> options) : base(options) { }


            public DbSet<MãeModel> Mães { get; set; }
            public DbSet<RNModel> RNs { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<RNModel>()
                    .HasOne(rn => rn.Mãe)
                    .WithMany()
                    .HasForeignKey(rn => rn.MãeId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }

