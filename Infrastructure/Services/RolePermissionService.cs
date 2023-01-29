
using Domain.Dto;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;

namespace Infrastructure.Services;


public class RolePermissionService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public RolePermissionService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetRolePermissionDto>>> Get()
    {
        try
        {
            var result = await _context.rolePermissions.ToListAsync();
            var mapped = _mapper.Map<List<GetRolePermissionDto>>(result);
            return new Response<List<GetRolePermissionDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetRolePermissionDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<AddRolePermissionDto>> Add(AddRolePermissionDto model)
    {
        
             try
        {
            var mapped = _mapper.Map<RolePermission>(model);
            await _context.rolePermissions.AddAsync(mapped);
            await _context.SaveChangesAsync();
            model.Id = mapped.Id;
            return new Response<AddRolePermissionDto>(model);

        }
        catch (System.Exception ex)
        {
            return  new Response<AddRolePermissionDto>(HttpStatusCode.InternalServerError,new List<string>(){ex.Message});
            
        }
        
    }

    public async Task<Response<AddRolePermissionDto>> Update(AddRolePermissionDto model)
    {

        try
        {
          
            var update =await _context.rolePermissions.Where(x=>x.Id == model.Id ).AsNoTracking().FirstOrDefaultAsync();
            if (update ==null)
            {
               
                return new Response<AddRolePermissionDto>(HttpStatusCode.BadRequest,new List<string>() { $"Role Permissions vijud nadora" });  
               
               
            }
            else
            {
                 var mapped = _mapper.Map<RolePermission>(model);
                _context.rolePermissions.Update(mapped);
                await _context.SaveChangesAsync();
                model.Id=mapped.Id;
                return new Response<AddRolePermissionDto>(model);

            }

        }
        catch (Exception e)
        {
            return  new Response<AddRolePermissionDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    public async Task<Response<GetRolePermissionDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.rolePermissions.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<GetRolePermissionDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<GetRolePermissionDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<GetRolePermissionDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
}




