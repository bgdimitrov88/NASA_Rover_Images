using Newtonsoft.Json;

namespace NASA_Rover_Images.Models
{
    public class Camera
    {
        public const string FHAZ = "FHAZ";
        public const string RHAZ = "RHAZ";
        public const string MAST = "MAST";
        public const string CHEMCAM = "CHEMCAM";
        public const string MAHLI = "MAHLI";
        public const string MARDI = "MARDI";
        public const string NAVCAM = "NAVCAM";
        public const string PANCAM = "PANCAM";
        public const string MINITES = "MINITES";

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
