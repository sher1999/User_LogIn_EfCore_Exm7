using System.ComponentModel.DataAnnotations;
namespace Domain.Dto;

public class UserrLoginnDto
{
     [Required]
    public string UserName{get;set;}
      [Required]
    public string Password {get;set;}
}
