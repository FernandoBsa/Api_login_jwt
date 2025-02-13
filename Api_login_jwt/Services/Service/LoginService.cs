using Domain.Interfaces;
using Services.Authentication;
using Services.Interface;
using Services.Request;
using Services.Response;
using Services.Results;

namespace Services.Service;

public class LoginService : ILoginService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ITokenManager _tokenManager;

    public LoginService(IUsuarioRepository usuarioRepository, ITokenManager tokenManager)
    {
        _usuarioRepository = usuarioRepository;
        _tokenManager = tokenManager;
    }

    public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request)
    {
        try
        {
            if (request == null)
                return Result<LoginResponse>.Failure(Error.Validation("LoginService.MissingEntity", "Entity cannot be null"));
            
            var usuario = await _usuarioRepository.GetByEmailWithRoles(request.Email);
            
            if (usuario == null)
                return Result<LoginResponse>.Failure(Error.NotFound("LoginService.NotFound", "User not found"));
            
            bool senhaValida = BCrypt.Net.BCrypt.Verify(request.Password, usuario.Senha);
            
            if (!senhaValida)
                return Result<LoginResponse>.Failure(Error.Validation("LoginService.InvalidCredentials", "Invalid password"));
            
            var token = _tokenManager.GerarToken(usuario);

            if (string.IsNullOrEmpty(token))
                return Result<LoginResponse>.Failure(Error.Validation("LoginService.MissingToken", "Token not generated"));
            
            var loginResponse = new LoginResponse(token);
            
            return Result<LoginResponse>.Success(loginResponse);
        }
        catch (Exception ex)
        {
            return Result<LoginResponse>.Failure(Error.Failure("UsuarioService.AddAsync", ex.Message));
        }
    }
}