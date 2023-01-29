using System.ComponentModel.DataAnnotations;

namespace Domain.Dto;

public class GetRoleDto
{
      public int Id {get;set;}
  [Required,MaxLength(50)] 
   public string Name { get; set; }
}
