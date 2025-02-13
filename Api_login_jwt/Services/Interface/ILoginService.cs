using Services.Request;
using Services.Response;
using Services.Results;

namespace Services.Interface;

public interface ILoginService
{
    Task<Result<LoginResponse>> LoginAsync(LoginRequest request);
}