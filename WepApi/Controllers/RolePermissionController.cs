
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

public class RolePermissionController : ControllerBase
{

    private readonly RolePermissionService _rolePermissionService;

    public RolePermissionController(RolePermissionService rolePermissionService)
    {
        _rolePermissionService = rolePermissionService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetRolePermissionDto>>> Gett()
    {
        return await _rolePermissionService.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddRolePermissionDto>> Addd(AddRolePermissionDto c)
    {
        if (ModelState.IsValid)
        {
            return await _rolePermissionService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddRolePermissionDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<AddRolePermissionDto>> Updatee( AddRolePermissionDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _rolePermissionService.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddRolePermissionDto>(HttpStatusCode.BadRequest, errors);
        }
        }
    [HttpDelete("{id}")]
    public async Task<Response<GetRolePermissionDto>>  Deletee(int id)
    {
       return await _rolePermissionService.Delete(id);
    
}

}



