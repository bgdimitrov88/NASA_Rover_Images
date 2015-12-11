using NASA_Rover_Images.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NASA_Rover_Images.Utils
{
    public interface INasaApiCommunicator
    {
        Task<Tuple<bool, IReadOnlyList<Photo>, Error>> GetPhotos(string rover, string camera, int sol);
    }
}
