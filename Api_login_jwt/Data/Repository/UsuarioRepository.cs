using Data.Context;
using Domain.Entity;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
{
    private readonly ApplicationDbContext _context;
    public UsuarioRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Usuario>> GetAllWithRoles()
    {
        var usuarios = _context.Usuarios.Include(u => u.UsuarioRoles).ThenInclude(ur => ur.Role);
        return await usuarios.ToListAsync();
    }
}