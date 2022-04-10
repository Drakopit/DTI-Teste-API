using DTI_Test.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DTI_Test.Repository
{
    public class DTIContext : DbContext
    {
        public DTIContext(DbContextOptions<DTIContext> options) : base(options) {}

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name);
                entity.Property(p => p.Count);
                entity.Property(p => p.Value);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
