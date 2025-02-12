using Domain.Entity;

namespace Domain.Interfaces;

public interface IUsuarioRepository : IGenericRepository<Usuario>
{
    Task<List<Usuario>> GetAllWithRoles();
}