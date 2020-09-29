using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ZettaWebServices.Utility;

namespace ZettaWebServices.Repository.Db.Context
{
    public partial class ZettaWebServiceContext : DbContext
    {
        public ZettaWebServiceContext()
        {
        }

        public ZettaWebServiceContext(DbContextOptions<ZettaWebServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SearchEngineSubmission> SearchEngineSubmission { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Initialize_StoredProcedures(modelBuilder);
            modelBuilder.Entity<SearchEngineSubmission>(entity =>
            {
                entity.HasKey(e => e.SubmissionNo);

                entity.Property(e => e.SubmissionUrl)
                    .IsRequired()
                    .HasColumnName("SubmissionURL")
                    .HasMaxLength(1000);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("IX_User")
                    .IsUnique();

                entity.Property(e => e.Aud).HasColumnName("aud");

                entity.Property(e => e.AuthTime).HasColumnName("auth_time");

                entity.Property(e => e.CHash).HasColumnName("c_hash");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedBy).HasMaxLength(256);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Exp).HasColumnName("exp");

                entity.Property(e => e.Iat).HasColumnName("iat");

                entity.Property(e => e.Iss).HasColumnName("iss");

                entity.Property(e => e.LastIpaddress)
                    .IsRequired()
                    .HasColumnName("LastIPAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.LastLoginOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Nbf).HasColumnName("nbf");

                entity.Property(e => e.Nonce).HasColumnName("nonce");

                entity.Property(e => e.Tfp).HasColumnName("tfp");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Ver).HasColumnName("ver");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
