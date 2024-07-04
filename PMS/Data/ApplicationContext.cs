using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PMS.Models.User;
using PMS.Models.PropertyData;

namespace PMS.Data


{
	public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<InvestmentProperty> Properties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProperty> UserProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProperty>()
                .HasKey(up => new { up.UserId, up.PropertyId });

            modelBuilder.Entity<UserProperty>()
                .HasOne(up => up.User)
                .WithMany(u => u.LikedProperties)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserProperty>()
                .HasOne(up => up.Property)
                .WithMany(p => p.LikedByUsers)
                .HasForeignKey(up => up.PropertyId);
        }
    }
}

