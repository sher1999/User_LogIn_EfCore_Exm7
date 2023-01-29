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

public class RoleController : ControllerBase
{

    private readonly RoleService _roleService;

    public RoleController(RoleService roleService)
    {
        _roleService = roleService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetRoleDto>>> Gett()
    {
        return await _roleService.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddRoleDto>> Addd(AddRoleDto c)
    {
        if (ModelState.IsValid)
        {
            return await _roleService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddRoleDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<AddRoleDto>> Updatee( AddRoleDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _roleService.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddRoleDto>(HttpStatusCode.BadRequest, errors);
        }
        }
    [HttpDelete("{id}")]
    public async Task<Response<GetRoleDto>>  Deletee(int id)
    {
       return await _roleService.Delete(id);
    
}

}


