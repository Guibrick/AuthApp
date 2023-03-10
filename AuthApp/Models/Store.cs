using System.Text.Json.Serialization;

namespace AuthApp.Models
{
    public class Store
    {
        [JsonPropertyName("uniqueStoreId")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}