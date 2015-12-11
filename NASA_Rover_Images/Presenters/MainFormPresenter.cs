using NASA_Rover_Images.Views;
using System.Collections.Generic;
using NASA_Rover_Images.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using NASA_Rover_Images.Utils;
using System;

namespace NASA_Rover_Images.Presenters
{
    public class MainFormPresenter : IMainFormPresenter
    {
        private readonly IMainView _mainView;
        private readonly IReadOnlyDictionary<string, IReadOnlyList<string>> _rovers;
        private readonly IRequest _request;
        private readonly INasaApiCommunicator _nasaApiCommunicator;

        public MainFormPresenter(IMainView mainView)
        {
            _mainView = mainView;
            _rovers = new Dictionary<string, IReadOnlyList<string>>()
            {
                { Rover.Curiosity, new List<string>() { "FHAZ", "RHAZ", "MAST", "CHEMCAM", "MAHLI", "MARDI", "NAVCAM" } },
                { Rover.Opportunity, new List<string>() { "FHAZ", "RHAZ", "NAVCAM", "PANCAM", "MINITES" } },
                { Rover.Spirit, new List<string>() { "FHAZ", "RHAZ", "NAVCAM", "PANCAM", "MINITES" } }
            };

            _request = new Request() { Camera = _rovers.First().Value.First(), Rover = _rovers.Keys.First(), Sol = 1000 };
            _nasaApiCommunicator = new NasaApiCommunicator();
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
            //Cannot use out parameters in async tasks so must return a tuple
            Tuple<bool, IReadOnlyList<Photo>, Error> _apiResult = await _nasaApiCommunicator.GetPhotos(Request.Rover, Request.Camera, Request.Sol);

            if (_apiResult.Item1)
            {
                _mainView.ShowPhotos(_apiResult.Item2);
            }
            else
            {
                _mainView.ShowError(_apiResult.Item3);
            }
        }
    }
}
