namespace OnlineCinema.BL.Entities.Auth;

public interface IAuthProvider
{
    Task<TokenResponse> AuthorizeUser(string email, string password);
}