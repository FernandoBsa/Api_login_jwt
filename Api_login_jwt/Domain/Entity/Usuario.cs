using System.Security.AccessControl;

namespace Domain.Entity;

public class Usuario : Base
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public ICollection<UsuarioRole> UsuarioRoles { get; set; }
}