using System.Text.Json.Serialization;

namespace MyMVC161124.Models
{
    public class Cat
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        [JsonPropertyName("width")]
        public required int Width { get; set; }
        [JsonPropertyName("height")]
        public required int Height { get; set; }
        [JsonPropertyName("url")]
        public required string Url { get; set; }
        [JsonPropertyName("breeds")]
        public List<Breed>? Breed { get; set; }  // List because JSON shows an array of breeds
    }
}
