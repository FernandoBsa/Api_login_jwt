using Domain.Entity;

namespace Domain.Interfaces;

public interface IUsuarioRepository : IGenericRepository<Usuario>
{
    Task<List<Usuario>> GetAllWithRoles();
    Task<Usuario> GetByIdWhitRole(Guid Id);
    Task<Usuario> GetByEmailWithRoles(string email);
}