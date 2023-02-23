using AuthApp.Models;

namespace AuthApp.Services
{
    public interface IUserService
    {
        Task<UserListResponse?> GetUsers();
        Task<UserResponse?> GetUser(int id);
        Task<UserResponse?> Register(UserRegisterRequest userRegister);

    }
}