namespace Domain.Entity;

public class Role : Base
{
    public string UserRole { get; set; }
    public ICollection<UsuarioRole > UsuarioRoles  { get; set; }
}