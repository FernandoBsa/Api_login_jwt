using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Request;
using Services.Result;
using WebApi.Extensions;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IResult> GetAllAsync()
    {   
        var result = await _usuarioService.GetAllAsync();
        
        return Results.Extensions.MapResult(result);
    }

    [HttpPost]
    public async Task<IResult> AddAsync(AddUsuarioRequest usuario)
    {
        var result = await _usuarioService.AddAsync(usuario);

        return Results.Extensions.MapResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var result = await _usuarioService.GetByIdAsync(id);
        
        return Results.Extensions.MapResult(result);
    }

    [HttpPut]
    public async Task<IResult> UpdateAsync(Usuario usuario)
    {
        var result = await _usuarioService.UpdateAsync(usuario);
        
        return Results.Extensions.MapResult(result);
    }

    [HttpDelete]
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var result = await _usuarioService.DeleteAsync(id);
        
        return Results.Extensions.MapResult(result);
    }
}