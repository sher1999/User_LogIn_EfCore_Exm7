using Domain.Dto;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;

namespace Infrastructure.Services;


public class UserService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<UserrRegisterrDto>>> Get()
    {
        try
        {
            var result = await _context.users.ToListAsync();
            var mapped = _mapper.Map<List<UserrRegisterrDto>>(result);
            return new Response<List<UserrRegisterrDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<UserrRegisterrDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<List<string>>> Login(UserrLoginnDto model)
    {
        try
        { var existing =await _context.users.FirstOrDefaultAsync(x=>(x.FirstName == model.UserName || x.LastName ==model.UserName) &&  x.Password == model.Password );
            if (existing!=null)
            {
                
                   var result = await _context.users.ToListAsync();
            var mapped = _mapper.Map<List<UserrLoginnDto>>(result);
            return new Response<List<string>>( new List<string>() { $"Welcome" });
            }
            else
            {
       return new Response<List<string>>(HttpStatusCode.BadRequest,  new List<string>() { $" Password yoki Name nodurust meboshad" }); 
  
            }
         
        }
        catch (Exception e)
        {
            return new Response<List<string>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<UserrRegisterrDto>> Add(UserrRegisterrDto model)
    {
        try
        {
              var existing = _context.users.Where(x =>x.Email == model.Email ||  x.MobileNumber == model.MobileNumber).FirstOrDefault();
            if (existing == null)
            {
                 var mapped = _mapper.Map<User>(model);
            await _context.users.AddAsync(mapped);
            await _context.SaveChangesAsync();
            model.Id=mapped.Id;
            return new Response<UserrRegisterrDto>(model);
            }
           
            return new Response<UserrRegisterrDto>(HttpStatusCode.BadRequest,
                    new List<string>(){$" Email or MobileNumber vujud dorad "});
        }
        catch (Exception e)
        {
            return  new Response<UserrRegisterrDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

    public async Task<Response<UserrRegisterrDto>> Update(UserrRegisterrDto model)
    {

        try
        {
          
            var update =await _context.users.Where(x=>x.Id == model.Id).AsNoTracking().FirstOrDefaultAsync();
            if (update !=null)
            {
                var mapped = _mapper.Map<User>(model);
                _context.users.Update(mapped);
                await _context.SaveChangesAsync();
                model.Id=mapped.Id;
                return new Response<UserrRegisterrDto>(model);
               
               
            }
            else
            {
                return new Response<UserrRegisterrDto>(HttpStatusCode.BadRequest,new List<string>() { $"UserId vijud nadora" });  

            }

        }
        catch (Exception e)
        {
            return  new Response<UserrRegisterrDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
 
    }


    public async Task<Response<UserrRegisterrDto>> Delete(int id)
    {
        try
        {  
            
            var entity=await _context.users.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (entity==null)
            {
                return new Response<UserrRegisterrDto>(HttpStatusCode.BadRequest,
                    new List<string>() { $"Id {id} vijud nadora" });
            }
            else
            {
                _context.Remove(entity);
                await  _context.SaveChangesAsync();
              
                return new Response<UserrRegisterrDto>();
            }
        }
        catch (Exception e)
        {
            return  new Response<UserrRegisterrDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});

        }
     
    }
    
}






