
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

public class UserRoleController : ControllerBase
{

    private readonly UserRoleService _userRoleService;

    public UserRoleController(UserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetUserRoleDto>>> Gett()
    {
        return await _userRoleService.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddUserRoleDto>> Addd(AddUserRoleDto c)
    {
        if (ModelState.IsValid)
        {
            return await _userRoleService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddUserRoleDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<AddUserRoleDto>> Updatee( AddUserRoleDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _userRoleService.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddUserRoleDto>(HttpStatusCode.BadRequest, errors);
        }
        }
    [HttpDelete("{id}")]
    public async Task<Response<GetUserRoleDto>>  Deletee(int id)
    {
       return await _userRoleService.Delete(id);
    
}

}


