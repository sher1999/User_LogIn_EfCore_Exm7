using System.ComponentModel.DataAnnotations;

namespace Domain.Dto;

public class UserrRegisterrDto
{
     public int Id {get;set;}
  [Required,MaxLength(50)] 
   public string FirstName { get; set; }
    [Required,MaxLength(50)]
    public string LastName { get; set; }
    [Required,MaxLength(50)]
    public string Email { get; set; }
    [Required,MaxLength(15)]
     public string MobileNumber { get; set; }
    
     [Required(ErrorMessage = "Password is required")]
[StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
[DataType(DataType.Password)]
public string Password { get; set; }

[Required(ErrorMessage = "Confirm Password is required")]
[StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
[DataType(DataType.Password)]
[Compare("Password")]
public string ConfirmPassword { get; set; }
}



