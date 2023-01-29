
using Domain.Dto;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;

namespace Infrastructure.Services;


public class UserRoleService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserRoleService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetUserRoleDto>>> Get()
    {
        try
        {
            var result = await _context.userRoles.ToListAsync();
            var mapped = _mapper.Map<List<GetUserRoleDto>>(result);
            return new Response<List<GetUserRoleDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetUserRoleDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<AddUserRoleDto>> Add(AddUserRoleDto model)
    {
        try
        {
            var existing =await _context.userRoles.FirstOrDefaultAsync(x=>x.Id != model.Id);
            if (existing == null)
            {
                var mapped = _mapper.Map<UserRole>(model);
            await _context.userRoles.AddAsync(mapped);
            await _context.SaveChangesAsync();
            model.Id=mapped.Id;
            return new Response<AddUserRoleDto>(model);
           
            }
                 return new Response<AddUserRoleDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "A User Role with such data already exists" });
        }
        catch (Exception e)
        {
            return  new Response<AddUserRoleDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    public async Task<Response<AddUserRoleDto>> Update(AddUserRoleDto model)
    {

        try
        {
          
            var update =await _context.userRoles.Where(x=>x.Id == model.Id ).AsNoTracking().FirstOrDefaultAsync();
            if (update !=null)
            {
                var mapped = _mapper.Map<UserRole>(model);
                _context.userRoles.Update(mapped);
                await _context.SaveChangesAsync();
                model.Id=mapped.Id;
                return new Response<AddUserRoleDto>(model);
               
               
            }
            else
            {
                return new Response<AddUserRoleDto>(HttpStatusCode.BadRequest,new List<string>() { $"User Role vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<AddUserRoleDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    public async Task<Response<GetUserRoleDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.userRoles.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<GetUserRoleDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<GetUserRoleDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<GetUserRoleDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
}




