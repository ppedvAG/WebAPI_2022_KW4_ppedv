using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MovieAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public GenreType Genre { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum GenreType { Action=1, Thriller, Comedy, Drama, Horror, Documentation}
}
