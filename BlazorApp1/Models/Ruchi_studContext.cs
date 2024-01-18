﻿#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Models;

public partial class Ruchi_studContext : DbContext
{
    public Ruchi_studContext(DbContextOptions<Ruchi_studContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SkillsTable> SkillsTables { get; set; }

    public virtual DbSet<StudTable> StudTables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SkillsTable>(entity =>
        {
            entity.HasKey(e => e.SkillId);

            entity.ToTable("Skills_Table");

            entity.Property(e => e.SkillId)
                .ValueGeneratedNever()
                .HasColumnName("SkillID");
            entity.Property(e => e.SkillName)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);
        });

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

            entity.HasMany(d => d.SkillsNavigation).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "CombinationTable",
                    r => r.HasOne<SkillsTable>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Combinati__Skill__4D94879B"),
                    l => l.HasOne<StudTable>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Combinati__Stude__4CA06362"),
                    j =>
                    {
                        j.HasKey("StudentId", "SkillId").HasName("PK__Combinat__5F3F236723ABE791");
                        j.ToTable("CombinationTable");
                        j.IndexerProperty<int>("StudentId").HasColumnName("StudentID");
                        j.IndexerProperty<int>("SkillId").HasColumnName("SkillID");
                    });
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}