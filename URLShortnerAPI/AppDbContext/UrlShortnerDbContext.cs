﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using URLShortnerAPI.Models;

namespace URLShortnerAPI.AppDbContext
{
    public class UrlShortnerDbContext : DbContext
    {
        public UrlShortnerDbContext()
        {
        }

        public UrlShortnerDbContext(DbContextOptions<UrlShortnerDbContext> options) : base(options)
        {
        }

        public DbSet<URL> uRLs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<URL>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<URL>()
                .Property(b => b.OriginalUrl)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<URL>()
                .Property(b => b.URLCode)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<URL>()
                .Property(b => b.CreatedBy)
                .HasMaxLength(100);

            modelBuilder.Entity<URL>()
                .Property(b => b.LastModifiedBy)
                .HasMaxLength(100);

            modelBuilder.Entity<URL>()
                .Property(b => b.CreatedDate)
                .IsRequired();



            modelBuilder.Entity<URL>().HasData(new URL
            {
                Id = 1000000,
                OriginalUrl = "https://google.com",
                URLCode = "1a",
                CreatedDate = DateTime.Now
            });

        }
    }
}
