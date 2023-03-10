using AuthApp.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AuthApp.Services
{
    public class UserService : IUserService
    {
        static HttpClient client = new HttpClient();

        const string UserUrl = "https://localhost:7276/api/User";
        private HttpClient getClient()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        public async Task<UserListResponse?> GetUsers()
        {
            var client = getClient();
            var usersTask = client.GetStreamAsync(UserUrl);
            return await JsonSerializer.DeserializeAsync<UserListResponse?>(await usersTask);
        }
        public async Task<UserResponse?> GetUser(int id)
        {
            var client = getClient();
            var url = $"{UserUrl}{id}";

            var userTask = client.GetStreamAsync(url);

            return await JsonSerializer.DeserializeAsync<UserResponse?>(await userTask);
        }

        public async Task<UserResponse?> Register(UserRegisterRequest userRegister)
        {
            var user = new User
            {
                Id = GetUsers().Result.Users.Count() + 1,
                Email = userRegister.Email,
                Password = userRegister.Password,
                Role = userRegister.Role,
                StoreId = userRegister.StoreId,
            };

            var response = await client.PostAsJsonAsync(UserUrl, user);
            var result = await response.Content.ReadFromJsonAsync<UserResponse?>();

            return result;
        }
    }
}