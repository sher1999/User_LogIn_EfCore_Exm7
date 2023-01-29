using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;

public class Role
{
      public int Id {get;set;}
  [Required,MaxLength(50)] 
   public string Name { get; set; }
   public ICollection<UserRole> userRoles { get; set; }
    public ICollection<RolePermission> rolePermissions { get; set; }
}
