using NASA_Rover_Images.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace NASA_Rover_Images.Utils
{
    public class NasaApiCommunicator : INasaApiCommunicator
    {
        private const string _uriFormat = @"rovers/{0}/photos?camera={1}&sol={2}&api_key=API_KEY_GOES_HERE";
        //No need to dispose HttpClient after each request
        //http://chimera.labs.oreilly.com/books/1234000001708/ch14.html
        private HttpClient _httpClient;
        private JsonSerializer _jsonSerializer;

        public NasaApiCommunicator()
        {
            _httpClient = new HttpClient() { BaseAddress = new Uri("https://api.nasa.gov/mars-photos/api/v1/") };
            _jsonSerializer = JsonSerializer.Create();
        }

        public async Task<Tuple<bool, IReadOnlyList<Photo>, Error>> GetPhotos(string rover, string camera, int sol)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(_uriFormat, rover, camera, sol));
            string jsonObject = await response.Content.ReadAsStringAsync();
            var jsonTextReader = new JsonTextReader(new StringReader(jsonObject));

            if (response.IsSuccessStatusCode)
            {
                PhotosResponse photosResponse = _jsonSerializer.Deserialize<PhotosResponse>(jsonTextReader);

                return new Tuple<bool, IReadOnlyList<Photo>, Error>(true, photosResponse.Photos, null);
            }
            else
            {
                Error error = _jsonSerializer.Deserialize<Error>(jsonTextReader);

                return new Tuple<bool, IReadOnlyList<Photo>, Error>(true, null, error);
            }
        }
    }
}
