
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore ;


namespace Infrastructure.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options){

    }

   public DbSet<User> users {get;set;}
   public DbSet<Role> roles {get;set;}
   public DbSet<Permission> permissions {get;set;}
   public DbSet<UserRole> userRoles {get;set;}
   public DbSet<RolePermission> rolePermissions {get;set;}
   public DbSet<UserLogin> userLogins {get;set;}
   


  protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<RolePermission>()
        .HasKey(bc => new { bc.RoleId, bc.PermissionId });  
    modelBuilder.Entity<RolePermission>()
        .HasOne(bc => bc.Role)
        .WithMany(b => b.rolePermissions)
        .HasForeignKey(bc => bc.RoleId);  
    modelBuilder.Entity<RolePermission>()
        .HasOne(bc => bc.Permission)
        .WithMany(c => c.rolePermissions)
        .HasForeignKey(bc => bc.PermissionId);

    modelBuilder.Entity<UserRole>()
        .HasKey(bc => new { bc.UserId, bc.RoleId });  
    modelBuilder.Entity<UserRole>()
        .HasOne(bc => bc.User)
        .WithMany(b => b.userRoles)
        .HasForeignKey(bc => bc.UserId);  
    modelBuilder.Entity<UserRole>()
        .HasOne(bc => bc.Role)
        .WithMany(c => c.userRoles)
        .HasForeignKey(bc => bc.RoleId);
}


}
