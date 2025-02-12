using Domain.Entity;
using Services.Request;
using Services.Result;

namespace Services.Interface;

public interface IRoleService
{
    Task<Result<IEnumerable<Role>>> GetAllAsync();
    Task<Result<Role>> GetByIdAsync(Guid id);
    Task<Result<Role>> AddAsync(AddRoleRequest entity);
    Task<Result<Role>> UpdateAsync(Role entity);
    Task<Result<Role>> DeleteAsync(Guid id);
}