using Newtonsoft.Json;
using System.Collections.Generic;

namespace NASA_Rover_Images.Models
{
    public class PhotosResponse
    {
        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }
    }
}
