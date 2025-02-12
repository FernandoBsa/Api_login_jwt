namespace Domain.Entity;

public class UsuarioRole : Base
{
    public Guid IdRole { get; set; }
    public Role Role { get; set; }
    public Guid IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
}