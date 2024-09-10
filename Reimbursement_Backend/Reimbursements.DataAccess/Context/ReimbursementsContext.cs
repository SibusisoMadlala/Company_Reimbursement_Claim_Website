
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reimbursements.DataAccess.Context.Entities;


namespace Reimbursements.DataAccess.Context;

public class ReimbursementsContext : IdentityDbContext<ReimbursementsUser>
{
    public ReimbursementsContext(DbContextOptions<ReimbursementsContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<ReimbursementsUser>().HasOne(b => b.Bank)
                .WithMany(s => s.Users)
                .HasForeignKey(h => h.BankId);
    }
}
