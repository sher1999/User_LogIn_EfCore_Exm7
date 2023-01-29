
using Domain.Dto;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;

namespace Infrastructure.Services;


public class RoleService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public RoleService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetRoleDto>>> Get()
    {
        try
        {
            var result = await _context.roles.ToListAsync();
            var mapped = _mapper.Map<List<GetRoleDto>>(result);
            return new Response<List<GetRoleDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetRoleDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<AddRoleDto>> Add(AddRoleDto model)
    {
        try
        {
            var existing =await _context.roles.FirstOrDefaultAsync(x=>x.Name != model.Name);
            if (existing != null)
            {
                var mapped = _mapper.Map<Role>(model);
            await _context.roles.AddAsync(mapped);
            await _context.SaveChangesAsync();
            model.Id=mapped.Id;
            return new Response<AddRoleDto>(model);
           
            }
                 return new Response<AddRoleDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "A Permission with such data already exists" });
        }
        catch (Exception e)
        {
            return  new Response<AddRoleDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    public async Task<Response<AddRoleDto>> Update(AddRoleDto model)
    {

        try
        {
          
            var update =await _context.roles.Where(x=>x.Name != model.Name ).AsNoTracking().FirstOrDefaultAsync();
            if (update !=null)
            {
                var mapped = _mapper.Map<Role>(model);
                _context.roles.Update(mapped);
                await _context.SaveChangesAsync();
                model.Id=mapped.Id;
                return new Response<AddRoleDto>(model);
               
               
            }
            else
            {
                return new Response<AddRoleDto>(HttpStatusCode.BadRequest,new List<string>() { $"Permission Name vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<AddRoleDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    public async Task<Response<GetRoleDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.roles.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<GetRoleDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<GetRoleDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<GetRoleDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
}



