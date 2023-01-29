
using Domain.Dto;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Domain.Wrapper;

namespace Infrastructure.Services;


public class UserLoginService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserLoginService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetUserLoginDto>>> Get()
    {
        try
        {
            var result = await _context.userLogins.ToListAsync();
            var mapped = _mapper.Map<List<GetUserLoginDto>>(result);
            return new Response<List<GetUserLoginDto>>(mapped);
        }
        catch (Exception e)
        {
            return new Response<List<GetUserLoginDto>>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
        
      
       
    }
    public async Task<Response<AddUserLoginDto>> Add(AddUserLoginDto model)
    {
        try
        {
            var existing =await _context.userLogins.FirstOrDefaultAsync(x=>x.Id != model.Id);
            if (existing == null)
            {
                var mapped = _mapper.Map<UserLogin>(model);
            await _context.userLogins.AddAsync(mapped);
            await _context.SaveChangesAsync();
            model.Id=mapped.Id;
            return new Response<AddUserLoginDto>(model);
           
            }
                 return new Response<AddUserLoginDto>(HttpStatusCode.BadRequest,
                    new List<string>());
        }
        catch (Exception e)
        {
            return  new Response<AddUserLoginDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
    }

   
    
}










