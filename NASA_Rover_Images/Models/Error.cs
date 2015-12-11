using Newtonsoft.Json;
namespace NASA_Rover_Images.Models
{
    public class Error
    {
        [JsonProperty("errors")]
        public string Errors { get; set; }
    }
}
