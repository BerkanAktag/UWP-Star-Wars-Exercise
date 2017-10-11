using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StarWars.Domain
{
    public class Movie
    {
        public string Title { get; set; }


        [JsonProperty(PropertyName = "episode_id")]
        public int EpisodeId { get; set; }

        [JsonProperty(PropertyName = "opening_crawl")]
        public string OpeningCrawl { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Planet> Planets { get; set; }

        [JsonProperty(PropertyName = "planets")]
        public List<string> PlanetUris { get; set; }

    }
}
