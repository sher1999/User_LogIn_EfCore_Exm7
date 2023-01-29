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

public class UserLoginController : ControllerBase
{

    private readonly UserLoginService _userLoginService;

    public UserLoginController(UserLoginService userLoginService)
    {
        _userLoginService = userLoginService;
    }


    [HttpGet("Get")]
    public async Task<Response<List<GetUserLoginDto>>> Gett()
    {
        return await _userLoginService.Get();
    }

    [HttpPost("Add")]
    public async Task<Response<AddUserLoginDto>> Addd(AddUserLoginDto c)
    {
        if (ModelState.IsValid)
        {
            return await _userLoginService.Add(c);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddUserLoginDto>(HttpStatusCode.BadRequest, errors);
        }
    }


}



