using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UsuarioRole> UsuarioRoles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Nome)
            .IsUnique();

        modelBuilder.Entity<UsuarioRole>()
            .HasKey(ur => ur.Id); 

        modelBuilder.Entity<UsuarioRole>()
            .HasOne(ur => ur.Usuario)
            .WithMany(u => u.UsuarioRoles)
            .HasForeignKey(ur => ur.IdUsuario);

        modelBuilder.Entity<UsuarioRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UsuarioRoles)
            .HasForeignKey(ur => ur.IdRole);

        modelBuilder.Entity<UsuarioRole>()
            .HasIndex(ur => new { ur.IdUsuario, ur.IdRole })
            .IsUnique();
    }
}