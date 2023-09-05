using AUCKPOLLWEB.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AUCKPOLLWEB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AUCKPOLLWEB.Areas.Identity.Data;

public class AUCKPOLLWEBContextDb : IdentityDbContext<AUCKPOLLWEBUser>
{
    public AUCKPOLLWEBContextDb(DbContextOptions<AUCKPOLLWEBContextDb> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new AUCKPOLLWEBUserEntityConfiguration());
    }

    public DbSet<AUCKPOLLWEB.Models.regions> regions { get; set; } = default!;

    public DbSet<AUCKPOLLWEB.Models.airQuality> airQuality { get; set; } = default!;

    public DbSet<AUCKPOLLWEB.Models.estuaryQuality> estuaryQuality { get; set; } = default!;

    public DbSet<AUCKPOLLWEB.Models.gWaterQuality> gWaterQuality { get; set; } = default!;
}

public class AUCKPOLLWEBUserEntityConfiguration : IEntityTypeConfiguration<AUCKPOLLWEBUser>
{
    public void Configure(EntityTypeBuilder<AUCKPOLLWEBUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}