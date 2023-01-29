using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;


public class User
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
     [Required,MinLength(5),MaxLength(255)]
     public string Password {get;set;}

     public List<UserLogin> UserLogins {get;set;}
     
     public ICollection<UserRole> userRoles { get; set; }


     public User()
     {
        
     }

  }
