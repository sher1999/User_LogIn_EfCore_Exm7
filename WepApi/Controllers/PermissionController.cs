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

public class PermissionController : ControllerBase
{

    private readonly PermissionServise _permissionServise;

    public PermissionController(PermissionServise permissionServise)
    {
        _permissionServise = permissionServise;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetPermissionDto>>> Gett()
    {
        return await _permissionServise.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddPermissionDto>> Addd(AddPermissionDto c)
    {
        if (ModelState.IsValid)
        {
            return await _permissionServise.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddPermissionDto>(HttpStatusCode.BadRequest, errors);
        }
    }

    [HttpPut("Update")]
    public async Task<Response<AddPermissionDto>> Updatee( AddPermissionDto c) 
    {
        if (ModelState.IsValid)
        {
            return await _permissionServise.Update(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddPermissionDto>(HttpStatusCode.BadRequest, errors);
        }
        }
    [HttpDelete("{id}")]
    public async Task<Response<GetPermissionDto>>  Deletee(int id)
    {
       return await _permissionServise.Delete(id);
    
}

}


