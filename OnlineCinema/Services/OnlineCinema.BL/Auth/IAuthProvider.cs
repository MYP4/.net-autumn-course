namespace OnlineCinema.BL.Entities.Auth;

public interface IAuthProvider
{
    Task<TokenResponse> AuthorizeUser(string email, string password);

    Task RegisterUser(string email, string password, string name, string surname);
}
