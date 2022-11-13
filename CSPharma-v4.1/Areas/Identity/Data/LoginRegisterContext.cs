using CSPharma_v4._1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace CSPharma_v4._1.Areas.Identity.Data;

public class LoginRegisterContext : IdentityDbContext<UserAuthentication>
{
    public LoginRegisterContext(DbContextOptions<LoginRegisterContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserEntityConfiguration());

        builder.HasDefaultSchema("dlk_torrecontrol");

        // builder.Entity<IdentityUser>().ToTable("Dlk_cat_acc_empleados");
    }
}

public class UserEntityConfiguration : IEntityTypeConfiguration<UserAuthentication>
{
    public void Configure(EntityTypeBuilder<UserAuthentication> builder)
    {
        builder.Property(usuario => usuario.UsuarioNombre).HasMaxLength(255);
        builder.Property(usuario => usuario.UsuarioApellidos).HasMaxLength(255);
    }
}