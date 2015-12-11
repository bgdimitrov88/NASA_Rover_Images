using NASA_Rover_Images.Views;
using System.Collections.Generic;
using NASA_Rover_Images.Models;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace NASA_Rover_Images.Presenters
{
    internal class Presenter : IPresenter
    {
        private IMainView _mainView;
        private readonly IReadOnlyDictionary<string, IReadOnlyList<string>> _rovers;
        private readonly IRequest _request;
        private const string _uriFormat = @"rovers/{0}/photos?camera={1}&sol={2}&api_key=API_KEY_GOES_HERE";
        //No need to dispose HttpClient after each request
        //http://chimera.labs.oreilly.com/books/1234000001708/ch14.html
        private HttpClient _httpClient;
        private JsonSerializer _jsonSerializer;

        public Presenter(IMainView mainView)
        {
            _mainView = mainView;
            _rovers = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "Curiosity", new List<string>() { "FHAZ", "RHAZ", "MAST", "CHEMCAM", "MAHLI", "MARDI", "NAVCAM" } },
                { "Opportunity", new List<string>() { "FHAZ", "RHAZ", "NAVCAM", "PANCAM", "MINITES" } },
                { "Spirit", new List<string>() { "FHAZ", "RHAZ", "NAVCAM", "PANCAM", "MINITES" } }
            };

            _request = new Request() { Camera = _rovers.First().Value.First(), Rover = _rovers.Keys.First(), Sol = 1000 };
            _httpClient = new HttpClient() { BaseAddress = new Uri("https://api.nasa.gov/mars-photos/api/v1/") };
            _jsonSerializer = JsonSerializer.Create();
        }
        
        public IReadOnlyDictionary<string, IReadOnlyList<string>> Rovers
        {
            get
            {
                return _rovers;
            }
        }

        public IRequest Request
        {
            get
            {
                return _request;
            }
        }

        public async void GetImages()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(_uriFormat, Request.Rover, Request.Camera, Request.Sol));
            string jsonObject = await response.Content.ReadAsStringAsync();
            var jsonTextReader = new JsonTextReader(new StringReader(jsonObject));

            if (response.IsSuccessStatusCode)
            {
                PhotosResponse photosResponse = _jsonSerializer.Deserialize<PhotosResponse>(jsonTextReader);
                _mainView.ShowPhotos(photosResponse.Photos);
            }
            else
            {
                Error error = _jsonSerializer.Deserialize<Error>(jsonTextReader);
                _mainView.ShowError(error);
            }
        }
    }
}
