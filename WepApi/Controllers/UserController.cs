using Domain.Entities;  
using Domain.Dto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using Domain.Wrapper;
namespace WepApi.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{

    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<UserrRegisterrDto>>> Gett()
    {
        return await _userService.Get();
    }
    

    [HttpPost("Add")]
    public async Task<Response<UserrRegisterrDto>> Addd(UserrRegisterrDto c)
    {
        if (ModelState.IsValid)
        {
            return await _userService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<UserrRegisterrDto>(HttpStatusCode.BadRequest, errors);
        }
    }
    [HttpPost("Login")]
    public async Task<Response<List<string>>>  Login(UserrLoginnDto Login)
    {
       
         if (ModelState.IsValid)
        {
             return await _userService.Login(Login);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<List<string>>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<UserrRegisterrDto>> Updatee( UserrRegisterrDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _userService.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<UserrRegisterrDto>(HttpStatusCode.BadRequest, errors);
        }
        }
    [HttpDelete("{id}")]
    public async Task<Response<UserrRegisterrDto>>  Deletee(int id)
    {
       return await _userService.Delete(id);
    
}

}

