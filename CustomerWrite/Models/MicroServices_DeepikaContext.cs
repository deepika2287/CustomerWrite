using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustomerWrite.Models
{
    public partial class MicroServices_DeepikaContext : DbContext
    {
        public MicroServices_DeepikaContext()
        {
        }

        public MicroServices_DeepikaContext(DbContextOptions<MicroServices_DeepikaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:microservicesdeepika.database.windows.net,1433;Initial Catalog=MicroServices_Deepika;Persist Security Info=False;User ID=sysadmin;Password=WhiteSands!1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
