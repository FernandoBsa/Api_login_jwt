using Domain.Entity;
using Services.Request;
using Services.Result;

namespace Services.Interface;

public interface IUsuarioRoleService
{
    Task<Result<IEnumerable<UsuarioRole>>> GetAllAsync();
    Task<Result<UsuarioRole>> GetByIdAsync(Guid id);
    Task<Result<UsuarioRole>> AddAsync(AddUsuarioRoleRequest entity);
    Task<Result<UsuarioRole>> UpdateAsync(UsuarioRole entity);
    Task<Result<UsuarioRole>> DeleteAsync(Guid id);
}