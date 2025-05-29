using FoodDesk.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodDesk.Persistence.Contexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var adminRole = new IdentityRole
        {
            Id = "1", // Статический Id
            Name = "admin",
            NormalizedName = "ADMIN"
        };

        var clientRole = new IdentityRole
        {
            Id = "2",
            Name = "client",
            NormalizedName = "CLIENT"
        };

        var courierRole = new IdentityRole
        {
            Id = "3",
            Name = "courier",
            NormalizedName = "COURIER"
        };

        builder.Entity<IdentityRole>().HasData(adminRole, clientRole, courierRole);
    }
}