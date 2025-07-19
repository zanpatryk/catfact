using System.Text.Json.Serialization;

namespace CatFact.Models
{
    public class Fact
    {
        [JsonPropertyName("fact")]
        public string Text { get; set; } = "";

        [JsonPropertyName("length")]
        public int Length { get; set; }
    }
}