using JwtAuthForUserLogin.Models;

namespace JwtAuthForUserLogin.Interfaces;

public interface IAuthService
{
    public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
}
