using Newtonsoft.Json;

namespace NASA_Rover_Images.Models
{
    public class Camera
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("rover_id")]
        public int RoverID { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
    }
}
