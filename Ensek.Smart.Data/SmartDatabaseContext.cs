﻿using Ensek.Smart.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Ensek.Smart.Data
{
    public class SmartDatabaseContext : DbContext
    {
        public required DbSet<Account> Accounts { get; set; }

        public required DbSet<MeterReading> MeterReadings { get; set; }

        public SmartDatabaseContext() { }

        public SmartDatabaseContext(DbContextOptions<SmartDatabaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(model =>
            {
                model.ToTable("Account");

                model.HasKey(a => a.AccountId);

                model.HasData(
                    new Account() { AccountId = 2344, FirstName = "Tommy", LastName = "Test" },
                    new Account() { AccountId = 2233, FirstName = "Barry", LastName = "Test" },
                    new Account() { AccountId = 8766, FirstName = "Sally", LastName = "Test" },
                    new Account() { AccountId = 2345, FirstName = "Jerry", LastName = "Test" },
                    new Account() { AccountId = 2346, FirstName = "Ollie", LastName = "Test" },
                    new Account() { AccountId = 2347, FirstName = "Tara", LastName = "Test" },
                    new Account() { AccountId = 2348, FirstName = "Tammy", LastName = "Test" },
                    new Account() { AccountId = 2349, FirstName = "Simon", LastName = "Test" },
                    new Account() { AccountId = 2350, FirstName = "Colin", LastName = "Test" },
                    new Account() { AccountId = 2351, FirstName = "Gladys", LastName = "Test" },
                    new Account() { AccountId = 2352, FirstName = "Greg", LastName = "Test" },
                    new Account() { AccountId = 2353, FirstName = "Tony", LastName = "Test" },
                    new Account() { AccountId = 2355, FirstName = "Arthur", LastName = "Test" },
                    new Account() { AccountId = 2356, FirstName = "Craig", LastName = "Test" },
                    new Account() { AccountId = 6776, FirstName = "Laura", LastName = "Test" },
                    new Account() { AccountId = 4534, FirstName = "JOSH", LastName = "TEST" },
                    new Account() { AccountId = 1234, FirstName = "Freya", LastName = "Test" },
                    new Account() { AccountId = 1239, FirstName = "Noddy", LastName = "Test" },
                    new Account() { AccountId = 1240, FirstName = "Archie", LastName = "Test" },
                    new Account() { AccountId = 1241, FirstName = "Lara", LastName = "Test" },
                    new Account() { AccountId = 1242, FirstName = "Tim", LastName = "Test" },
                    new Account() { AccountId = 1243, FirstName = "Graham", LastName = "Test" },
                    new Account() { AccountId = 1244, FirstName = "Tony", LastName = "Test" },
                    new Account() { AccountId = 1245, FirstName = "Neville", LastName = "Test" },
                    new Account() { AccountId = 1246, FirstName = "Jo", LastName = "Test" },
                    new Account() { AccountId = 1247, FirstName = "Jim", LastName = "Test" },
                    new Account() { AccountId = 1248, FirstName = "Pam", LastName = "Test" }
                );
            });

            modelBuilder.Entity<MeterReading>(model =>
            {
                model.ToTable("MeterReading");

                model.HasKey(m => m.MeterReadingId);

                model.Property(m => m.MeterReadValue)
                    .IsFixedLength(true)
                    .HasMaxLength(5);

                model.HasOne(m => m.Account)
                    .WithMany(a => a.MeterReadings)
                    .HasForeignKey(m => m.AccountId)
                    .IsRequired();
            });
        }
    }
}