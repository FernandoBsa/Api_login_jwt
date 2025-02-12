using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Request;
using WebApi.Extensions;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioRoleController : ControllerBase
{
    private readonly IUsuarioRoleService _usuarioRoleService;

    public UsuarioRoleController(IUsuarioRoleService usuarioRoleService)
    {
        _usuarioRoleService = usuarioRoleService;
    }
    
    [HttpGet]
    public async Task<IResult> GetAllAsync()
    {   
        var result = await _usuarioRoleService.GetAllAsync();
        
        return Results.Extensions.MapResult(result);
    }

    [HttpPost]
    public async Task<IResult> AddAsync(AddUsuarioRoleRequest usuario)
    {
        var result = await _usuarioRoleService.AddAsync(usuario);

        return Results.Extensions.MapResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var result = await _usuarioRoleService.GetByIdAsync(id);
        
        return Results.Extensions.MapResult(result);
    }

    [HttpPut]
    public async Task<IResult> UpdateAsync(UsuarioRole usuario)
    {
        var result = await _usuarioRoleService.UpdateAsync(usuario);
        
        return Results.Extensions.MapResult(result);
    }

    [HttpDelete]
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var result = await _usuarioRoleService.DeleteAsync(id);
        
        return Results.Extensions.MapResult(result);
    }
}