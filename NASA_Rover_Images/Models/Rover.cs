using Newtonsoft.Json;
using System.Collections.Generic;

namespace NASA_Rover_Images.Models
{
    public class Rover
    {
        public const string Curiosity = "Curiosity";
        public const string Opportunity = "Opportunity";
        public const string Spirit = "Spirit";
        
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("landing_date")]
        public string LandingDate { get; set; }
        [JsonProperty("max_sol")]
        public int MaxSol { get; set; }
        [JsonProperty("max_date")]
        public string MaxDate { get; set; }
        [JsonProperty("total_photos")]
        public int TotalPhotos { get; set; }
        [JsonProperty("cameras")]
        public List<Camera> Cameras { get; set; }
    }
}
