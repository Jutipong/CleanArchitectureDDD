﻿using System;
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

    public virtual DbSet<Customer> Customer { get; set; }

    public virtual DbSet<DBD_Log> DBD_Log { get; set; }

    public virtual DbSet<Transection> Transection { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Customer__3214EC27FCB0C552");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.Code).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<DBD_Log>(entity =>
        {
            entity.Property(e => e.id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Transection>(entity =>
        {
            entity.Property(e => e.TransectionId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
