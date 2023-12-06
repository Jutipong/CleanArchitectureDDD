using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Databases.SqlServer;

public partial class SqlContext : DbContext
{
    public SqlContext(DbContextOptions<SqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Article { get; set; }

    public virtual DbSet<Config_OTP> Config_OTP { get; set; }

    public virtual DbSet<Config_WrongAnswer> Config_WrongAnswer { get; set; }

    public virtual DbSet<Customer> Customer { get; set; }

    public virtual DbSet<Ms_Channel> Ms_Channel { get; set; }

    public virtual DbSet<Ms_CustomerType> Ms_CustomerType { get; set; }

    public virtual DbSet<Ms_EndCallReason> Ms_EndCallReason { get; set; }

    public virtual DbSet<Ms_Level> Ms_Level { get; set; }

    public virtual DbSet<Ms_Message> Ms_Message { get; set; }

    public virtual DbSet<Ms_ProductType> Ms_ProductType { get; set; }

    public virtual DbSet<Ms_Question> Ms_Question { get; set; }

    public virtual DbSet<Ms_ServiceType> Ms_ServiceType { get; set; }

    public virtual DbSet<Ms_TopicType> Ms_TopicType { get; set; }

    public virtual DbSet<Ms_VerificationReason> Ms_VerificationReason { get; set; }

    public virtual DbSet<Ms_VerifyType> Ms_VerifyType { get; set; }

    public virtual DbSet<UserTest> UserTest { get; set; }

    public virtual DbSet<VerifyCustomer> VerifyCustomer { get; set; }

    public virtual DbSet<VerifyQuestion> VerifyQuestion { get; set; }

    public virtual DbSet<vEmployee> vEmployee { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Config_OTP>(entity =>
        {
            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<Config_WrongAnswer>(entity =>
        {
            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC2725DE0E29");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Ms_Channel>(entity =>
        {
            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<Ms_CustomerType>(entity =>
        {
            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<Ms_EndCallReason>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_Ms_Reason");

            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<Ms_Level>(entity =>
        {
            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<Ms_Message>(entity =>
        {
            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<Ms_ProductType>(entity =>
        {
            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<Ms_Question>(entity =>
        {
            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<Ms_ServiceType>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_Ms_MsServiceType");

            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<Ms_TopicType>(entity =>
        {
            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<Ms_VerificationReason>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_Ms_Reason_Verification");

            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<Ms_VerifyType>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_Ms_Verify");

            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<UserTest>(entity =>
        {
            entity.Property(e => e.ID)
                .HasDefaultValueSql("(newsequentialid())")
                .HasComment("aaaaa");
            entity.Property(e => e.IsActive).IsFixedLength();
            entity.Property(e => e.Last).HasComment("ccccc");
            entity.Property(e => e.Name).HasComment("aaaaaa");
        });

        modelBuilder.Entity<VerifyCustomer>(entity =>
        {
            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.IsActive)
                .HasDefaultValue("Y")
                .IsFixedLength();
        });

        modelBuilder.Entity<VerifyQuestion>(entity =>
        {
            entity.Property(e => e.ID).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<vEmployee>(entity =>
        {
            entity.ToView("vEmployee");

            entity.Property(e => e.ADUser).UseCollation("Thai_CI_AI");
            entity.Property(e => e.Emp_Code).UseCollation("Thai_CI_AI");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
