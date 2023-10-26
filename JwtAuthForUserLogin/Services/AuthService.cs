using JwtAuthForUserLogin.Interfaces;
using JwtAuthForUserLogin.Models;

namespace JwtAuthForUserLogin.Services;

public class AuthService : IAuthService
{
    readonly ITokenService _tokenService;

    public AuthService(ITokenService tokenService)
    {
        this._tokenService = tokenService;
    }

    public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
    {
        UserLoginResponse response = new();

        if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
        {
            throw new ArgumentNullException(nameof(request));
        }

        if (request.Username == "george" && request.Password == "123456")
        {
            var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest { Username = request.Username });

            response.AuthenticateResult = true;
            response.AuthToken = generatedTokenInformation.Token; // json returning authToken string 
            response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
        }

        return response;
    }
}