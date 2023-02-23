using System.Text.Json.Serialization;

namespace AuthApp.Models
{
    public class UserResponse
    {
        [JsonPropertyName("data")]
        public User User { get; set; }
    }
}