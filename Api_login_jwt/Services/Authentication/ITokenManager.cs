using Domain.Entity;

namespace Services.Authentication;

public interface ITokenManager
{
    string GerarToken(Usuario usuario);
}