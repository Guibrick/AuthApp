using System.Text.Json.Serialization;

namespace AuthApp.Models
{
    public class UserListResponse
    {
        [JsonPropertyName("data")]
        public IList<User> Users { get; set; }
    }
}