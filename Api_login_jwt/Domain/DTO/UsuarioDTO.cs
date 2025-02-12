namespace Domain.DTO;

public class UsuarioDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
}