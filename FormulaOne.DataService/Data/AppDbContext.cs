﻿using Microsoft.EntityFrameworkCore;
using FormulaOne.Entities.DbSet;
using System;


namespace FormulaOne.DataService.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }

        public virtual DbSet<Achievement> Achievements { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Achievement>(entity => {
                entity.HasKey(e => e.Id);
                entity.HasOne(d => d.Driver)
                .WithMany(p => p.Achievements)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Achievements_Driver");
            });
        }
    }
}
