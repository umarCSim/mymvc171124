using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyMVC161124.Models
{
    public class CatImages
    {//TODO: Need to map this
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonPropertyName("id")]
        public required string CatId { get; set; }
        [JsonPropertyName("width")]
        public required int Width { get; set; }
        [JsonPropertyName("height")]
        public required int Height { get; set; }
        [JsonPropertyName("url")]
        public required string Url { get; set; }
    }
}
