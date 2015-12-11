using Newtonsoft.Json;

namespace NASA_Rover_Images.Models
{
    public class Photo
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("sol")]
        public int Sol { get; set; }
        [JsonProperty("camera")]
        public Camera Camera { get; set; }
        [JsonProperty("img_src")]
        public string ImgSrc { get; set; }
        [JsonProperty("earth_date")]
        public string EarthDate { get; set; }
        [JsonProperty("rover")]
        public Rover Rover { get; set; }
    }
}
