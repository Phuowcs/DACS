using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace testDACS.Models
{
    public partial class testDACScontext : DbContext
    {
        public testDACScontext()
            : base("name=testDACScontext")
        {
        }

        public virtual DbSet<BIENLAIHOCPHI> BIENLAIHOCPHIs { get; set; }
        public virtual DbSet<CHUNGCHI> CHUNGCHIs { get; set; }
        public virtual DbSet<CT_Lich_thi> CT_Lich_thi { get; set; }
        public virtual DbSet<DECUONG> DECUONGs { get; set; }
        public virtual DbSet<Du_thi> Du_thi { get; set; }
        public virtual DbSet<GIANGVIEN> GIANGVIENs { get; set; }
        public virtual DbSet<HOCVIEN> HOCVIENs { get; set; }
        public virtual DbSet<KHOAHOC> KHOAHOCs { get; set; }
        public virtual DbSet<LICHTHI> LICHTHIs { get; set; }
        public virtual DbSet<LINHVUC> LINHVUCs { get; set; }
        public virtual DbSet<LOP> LOPs { get; set; }
        public virtual DbSet<MONHOC> MONHOCs { get; set; }
        public virtual DbSet<THOIKHOABIEU> THOIKHOABIEUx { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHUNGCHI>()
                .Property(e => e.MACC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DECUONG>()
                .HasMany(e => e.MONHOCs)
                .WithRequired(e => e.DECUONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Du_thi>()
                .HasMany(e => e.CHUNGCHIs)
                .WithRequired(e => e.Du_thi)
                .HasForeignKey(e => new { e.MAHV, e.MAMH })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIANGVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<GIANGVIEN>()
                .HasMany(e => e.LOPs)
                .WithRequired(e => e.GIANGVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOCVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<HOCVIEN>()
                .HasMany(e => e.BIENLAIHOCPHIs)
                .WithRequired(e => e.HOCVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHOAHOC>()
                .HasMany(e => e.LOPs)
                .WithRequired(e => e.KHOAHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LINHVUC>()
                .HasMany(e => e.MONHOCs)
                .WithRequired(e => e.LINHVUC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOP>()
                .HasMany(e => e.BIENLAIHOCPHIs)
                .WithRequired(e => e.LOP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOP>()
                .HasMany(e => e.CT_Lich_thi)
                .WithRequired(e => e.LOP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONHOC>()
                .HasMany(e => e.BIENLAIHOCPHIs)
                .WithRequired(e => e.MONHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONHOC>()
                .HasMany(e => e.Du_thi)
                .WithRequired(e => e.MONHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THOIKHOABIEU>()
                .HasMany(e => e.LOPs)
                .WithRequired(e => e.THOIKHOABIEU)
                .WillCascadeOnDelete(false);
        }
    }
}
