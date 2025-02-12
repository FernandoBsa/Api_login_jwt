using Data.Context;
using Domain.Entity;
using Domain.Interfaces;

namespace Data.Repository;

public class UsuarioRoleRepository : GenericRepository<UsuarioRole>, IUsuarioRoleRepository
{
    public UsuarioRoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}