using EFWelcomeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace EFModelingApp
{
    public class CompaniesContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=Y5-0\MSSQLSERVER01;Initial Catalog=CompaniesDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            //modelBuilder.Ignore<Country>();
            //modelBuilder.Entity<Employee>().Ignore(e => e.DateBirth);

            //modelBuilder.Entity<Company>().Property("CompanyTitle").HasField("title");
            //modelBuilder.Entity<Company>().Property("CompanyCountry").HasField("country");

            

            // Required
            //modelBuilder.Entity<Employee>()
            //            .Property(e => e.DateBirth)
            //            .IsRequired();

            // Primary key
            //modelBuilder.Entity<Employee>()
            //            .HasKey(e => e.Id)
            //            .HasName("PrimaryKey_Employees");

            //modelBuilder.Entity<Employee>()
            //            .HasKey(e => new { e.PassportSeries, e.PassportNumber });

            // Unique key
            //modelBuilder.Entity<Employee>()
            //            .HasAlternateKey(e => e.Phone);

            // Indexes
            //modelBuilder.Entity<Employee>()
            //            .HasIndex(e => e.Name)
            //            .IsUnique()
            //            .IsDescending()
            //            .HasDatabaseName("NameIndex");

            // DataGeneration
            //modelBuilder.Entity<Employee>()
            //            .Property(e => e.Id)
            //            .ValueGeneratedNever();

            // Default value
            modelBuilder.Entity<Employee>()
                        .Property(e => e.Salary)
                        .HasDefaultValue(16000.0M);

            modelBuilder.Entity<Employee>()
                        .Property(e => e.Activity)
                        .HasDefaultValue(true);

            modelBuilder.Entity<Employee>()
                        .Property(e => e.BirthDate)
                        //.HasDefaultValue(DateTime.Now);
                        .HasDefaultValueSql("DATEADD(YEAR, -18, GETDATE())");

            modelBuilder.Entity<Employee>()
                        .Property(e => e.FullData)
                        .HasComputedColumnSql("Name + ' ' + Phone");

            modelBuilder.Entity<Employee>()
                        .ToTable(t => t.HasCheckConstraint("CK_BirthDate", "YEAR(GETDATE()) - YEAR(BirthDate) >= 18"));

            modelBuilder.Entity<Employee>()
                        .Property(e => e.Phone)
                        .HasMaxLength(50)
                        .HasMaxLength(3);

            modelBuilder.Entity<Employee>()
                        .HasData(
                new Employee() { Name = "Sammy" }
                );
        }
    }
}
