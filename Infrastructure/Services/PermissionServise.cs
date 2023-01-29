using Domain.Dto;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;

namespace Infrastructure.Services;


public class PermissionServise
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public PermissionServise(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetPermissionDto>>> Get()
    {
        try
        {
            var result = await _context.permissions.ToListAsync();
            var mapped = _mapper.Map<List<GetPermissionDto>>(result);
            return new Response<List<GetPermissionDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetPermissionDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<AddPermissionDto>> Add(AddPermissionDto model)
    {
        try
        {
            var existing =await _context.permissions.FirstOrDefaultAsync(x=>x.Name != model.Name);
            if (existing != null)
            {
                var mapped = _mapper.Map<Permission>(model);
            await _context.permissions.AddAsync(mapped);
            await _context.SaveChangesAsync();
            model.Id=mapped.Id;
            return new Response<AddPermissionDto>(model);
           
            }
                 return new Response<AddPermissionDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "A Permission with such data already exists" });
        }
        catch (Exception e)
        {
            return  new Response<AddPermissionDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    public async Task<Response<AddPermissionDto>> Update(AddPermissionDto model)
    {

        try
        {
          
            var update =await _context.permissions.Where(x=>x.Name != model.Name ).AsNoTracking().FirstOrDefaultAsync();
            if (update !=null)
            {
                var mapped = _mapper.Map<Permission>(model);
                _context.permissions.Update(mapped);
                await _context.SaveChangesAsync();
                model.Id=mapped.Id;
                return new Response<AddPermissionDto>(model);
               
               
            }
            else
            {
                return new Response<AddPermissionDto>(HttpStatusCode.BadRequest,new List<string>() { $"Permission Name vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<AddPermissionDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    public async Task<Response<GetPermissionDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.permissions.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<GetPermissionDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
                return new Response<GetPermissionDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<GetPermissionDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
}






