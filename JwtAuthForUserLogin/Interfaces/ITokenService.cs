using JwtAuthForUserLogin.Models;

namespace JwtAuthForUserLogin.Interfaces;

public interface ITokenService
{
    public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
}
