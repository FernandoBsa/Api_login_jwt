namespace Services.Request;

public class AddUsuarioRoleRequest
{
    public Guid IdUsuario { get; set; }
    public Guid IdRole { get; set; }
}