namespace MyMVC161124.Models
{
    public class Breed
    {
        public Weight? Weight { get; set; }
        public required string Id { get; set; }
        public required string Name { get; set; }
        public string? Temperament { get; set; }
        public string? Origin { get; set; }
        public string? Country_Codes { get; set; }
        public string? Country_Code { get; set; }
        public string? Life_Span { get; set; }
        public string? Wikipedia_Url { get; set; }
    }
}
