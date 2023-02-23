namespace AuthApp.Services
{
    public interface ITokenManager
    {
        string Authenticate(string email, string password);
    }
}