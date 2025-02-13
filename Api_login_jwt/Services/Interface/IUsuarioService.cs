using Domain.DTO;
using Domain.Entity;
using Services.Request;
using Services.Results;

namespace Services.Interface;

public interface IUsuarioService
{
    Task<Result<IEnumerable<UsuarioDTO>>> GetAllAsync();
    Task<Result<Usuario>> GetByIdAsync(Guid id);
    Task<Result<UsuarioDTO>> GetByIdWithRolesync(Guid id);
    Task<Result<Usuario>> AddAsync(AddUsuarioRequest entity);
    Task<Result<Usuario>> UpdateAsync(Usuario entity);
    Task<Result<Usuario>> DeleteAsync(Guid id);
}