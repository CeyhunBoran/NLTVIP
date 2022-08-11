using Newtonsoft.Json;

namespace Testapi.Data.Models
{
    public class MainCategory
    {
        public string Name { get; set; }
        public IList<SubCategory> Category { get ; set; }
    }
    public class SubCategory
    {
        public string ParentName { get; set; }
        public string Name { get; set; }
        public IList<Content> Contents { get;set; }
    }


    public class Content
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "Director")]
        public string Director { get; set; }
        [JsonProperty(PropertyName = "IMDbRating")]
        public double IMDbRating { get; set; }
        [JsonProperty(PropertyName = "Category")]
        public IList<string> Category { get; set; }
        [JsonProperty(PropertyName = "Writer")]
        public string Writer { get; set; }
        [JsonProperty(PropertyName = "Stars")]
        public string Stars { get; set; }
        [JsonProperty(PropertyName = "Poster")]
        public string Poster { get; set; }
        [JsonProperty(PropertyName = "Genre")]
        public string Genre { get; set; }
        [JsonProperty(PropertyName = "PlaybackURL")]
        public string PlaybackURL { get; set; }
    }
    public class Root
    {
        [JsonProperty(PropertyName = "Contents")]
        public IList<Content> Contents;
    }
}
