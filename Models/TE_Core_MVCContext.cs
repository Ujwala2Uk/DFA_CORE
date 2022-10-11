using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DFA_CORE.Models
{
    public partial class TE_Core_MVCContext : DbContext
    {
        public TE_Core_MVCContext()
        {
        }

        public TE_Core_MVCContext(DbContextOptions<TE_Core_MVCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Torder> Torders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ELW5143\\SQLEXPRESS;Database=TE_Core_MVC;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Torder>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("PK__TOrder__CB394B3914E8333C");

                entity.ToTable("TOrder");

                entity.Property(e => e.Oid)
                    .ValueGeneratedNever()
                    .HasColumnName("OID");

                entity.Property(e => e.Oitem)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("OItem");

                entity.Property(e => e.Oname)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("OName");

                entity.Property(e => e.Oquant).HasColumnName("OQuant");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
