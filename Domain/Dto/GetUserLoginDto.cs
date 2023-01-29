namespace Domain.Dto;

public class GetUserLoginDto
{
    
     public int Id {get;set;}
     public int UserId {get;set;}
    public DateTime LoginDate {get;set;}
    public DateTime  LogoutDate {get;set;}
    public GetUserLoginDto()
    {
        LoginDate = DateTime.UtcNow;
        LoginDate = DateTime.UtcNow;
    }

}
