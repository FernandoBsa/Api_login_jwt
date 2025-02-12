using Data.Context;
using Domain.Entity;
using Domain.Interfaces;

namespace Data.Repository;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}