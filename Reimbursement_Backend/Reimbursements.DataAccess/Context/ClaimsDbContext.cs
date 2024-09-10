using Microsoft.EntityFrameworkCore;
using Reimbursements.DataAccess.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Claim = Reimbursements.DataAccess.Context.Entities.Claim;

namespace Reimbursements.DataAccess.Context
{
    public class ClaimsDbContext : DbContext
    {
        public DbSet<Claim> Claims { get; set; }

        public DbSet<Bank> banks { get; set; }

        public DbSet<ReimbursementType> ReimbursementTypes { get; set; }

        public DbSet<Currency> currencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = ZA-5CD350K5SY ; Database = ReimbursementClaims ; Trusted_Connection=True  ; TrustServerCertificate = True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<ReimbursementType>().HasData(
                new ReimbursementType { Id=1, Name="Medical"},
                new ReimbursementType { Id=2, Name="Travel"},
                new ReimbursementType { Id=3, Name="Food"},
                new ReimbursementType { Id=4, Name="Misc"},
                new ReimbursementType { Id=5, Name="Entertainment"}
                
                );

            builder.Entity<Currency>().HasData(
                new Currency { Id = 1, CurrencyCode="INR" },
                new Currency { Id=2, CurrencyCode="ZAR"},
                new Currency { Id=3, CurrencyCode="USD"},
                new Currency { Id=4, CurrencyCode="EUR"}
                );

            builder.Entity<Bank>().HasData(
                new Bank { Id=1, BankName="Absa"},
                new Bank { Id=2, BankName="FNB"},
                new Bank { Id=3, BankName="Nedbank"},
                new Bank { Id=4, BankName="African"}
                
                );

            builder.Entity<Claim>().HasOne(c => c.Type)
                .WithMany(p => p.Claims)
                .HasForeignKey(k => k.TypeId);


            builder.Entity<Claim>().HasOne(q => q.Currency)
                .WithMany(p => p.Claims)
                .HasForeignKey(k => k.CurrencyId);

            builder.Entity<ReimbursementsUser>().HasOne(b => b.Bank)
                .WithMany(s => s.Users)
                .HasForeignKey(h => h.BankId);
        }
    }
}
