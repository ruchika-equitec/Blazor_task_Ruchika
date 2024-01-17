﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace BlazorApp1.Models;
public partial class Ruchi_studContext : DbContext
{
    public Ruchi_studContext(DbContextOptions<Ruchi_studContext> options)
        : base(options)
    {
    }

    public  DbSet<StudTable> StudTable { get; set; }
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudTable>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("StudTable");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.EmailId)
                .HasMaxLength(255)
                .HasColumnName("EmailID");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Skills)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}