using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Cuisin> Cuisins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new DbInitializer(modelBuilder).Seed();

            modelBuilder.Entity<Restaurant>(entity => {
                entity.HasKey(e => new { e.Id })
                    .HasName("PK_Restaurant");
                entity.Property(e => e.Id).HasColumnName("id")
                    .ValueGeneratedOnAdd();
                // Auto-increment
                entity.Property(e => e.Name).HasColumnName("Name")
                    .HasMaxLength(20).IsUnicode(false)
                    .IsRequired(true);
                entity.HasMany(e => e.Cuisins).WithOne(r => r.Restaurant)
                    .HasForeignKey(p => p.RestaurantId)
                    .HasConstraintName("FK_Cuisins_RestaurantId");
                entity.Property(e => e.Description)
                    .HasMaxLength(200); });


            modelBuilder.Entity<Cuisin>(entity =>
            {
                entity.HasKey(e => new { e.Id })
                    .HasName("PK_Cuisin");
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
                // Auto-increment               
                entity.HasOne(e => e.Restaurant)
                    .WithMany(r => r.Cuisins)
                    .HasForeignKey(p => p.RestaurantId)
                    .HasConstraintName("FK_Cuisins_RestaurantId");
            }); }
            }
}
