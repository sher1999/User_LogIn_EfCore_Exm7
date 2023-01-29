using AutoMapper;
using Domain.Dto;
using Domain.Entities;

// using Domain.Entities;
// using Domain.Dto;
namespace Infrastructure.MapperProfiles;

public class InfrastructureProfile : Profile
{
   public InfrastructureProfile()
   {
      CreateMap<User, UserrRegisterrDto>().ReverseMap();
      CreateMap<UserrLoginnDto, User>().ReverseMap();
      CreateMap<UserLogin, GetUserLoginDto>().ReverseMap();
      CreateMap<AddUserLoginDto, UserLogin>().ReverseMap();
      CreateMap<Permission, GetPermissionDto>().ReverseMap();
      CreateMap<AddPermissionDto, Permission>().ReverseMap();
      CreateMap<Role, GetRoleDto>().ReverseMap();
      CreateMap<AddRoleDto, Role>().ReverseMap();
      CreateMap<RolePermission, GetRolePermissionDto>().ReverseMap();
      CreateMap<AddRolePermissionDto, RolePermission>().ReverseMap();
      CreateMap<UserRole, GetUserRoleDto>().ReverseMap();
      CreateMap<AddUserRoleDto, UserRole>().ReverseMap();

     
   }
}
