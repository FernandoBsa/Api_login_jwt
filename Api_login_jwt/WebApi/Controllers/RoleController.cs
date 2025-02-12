using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Request;
using WebApi.Extensions;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IResult> GetAllAsync()
    {   
        var result = await _roleService.GetAllAsync();
        
        return Results.Extensions.MapResult(result);
    }

    [HttpPost]
    public async Task<IResult> AddAsync(AddRoleRequest role)
    {
        var result = await _roleService.AddAsync(role);

        return Results.Extensions.MapResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var result = await _roleService.GetByIdAsync(id);
        
        return Results.Extensions.MapResult(result);
    }

    [HttpPut]
    public async Task<IResult> UpdateAsync(Role role)
    {
        var result = await _roleService.UpdateAsync(role);
        
        return Results.Extensions.MapResult(result);
    }

    [HttpDelete]
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var result = await _roleService.DeleteAsync(id);
        
        return Results.Extensions.MapResult(result);
    }
}