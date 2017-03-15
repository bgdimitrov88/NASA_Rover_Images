using System.Collections.Generic;
using NASA_Rover_Images.Models;
using System.Linq;
using NASA_Rover_Images.Utils;
using System;

namespace NASA_Rover_Images.Presenters.MainForm
{
    public class MainFormPresenter : IMainFormPresenter
    {
        private readonly IReadOnlyDictionary<string, IReadOnlyList<string>> _roverCameras;
        private readonly IReadOnlyDictionary<string, DateTime> _roverLandingDates;
        private readonly IRequest _request;
        private readonly INasaApiCommunicator _nasaApiCommunicator;
        
        public MainFormPresenter(INasaApiCommunicator nasaApiCommunicator, IRequest initialRequest)
        {
            _roverCameras = new Dictionary<string, IReadOnlyList<string>>()
            {
                { Rover.Curiosity, new List<string>() { Camera.FHAZ, Camera.RHAZ, Camera.MAST, Camera.CHEMCAM, Camera.MAHLI, Camera.MARDI, Camera.NAVCAM } },
                { Rover.Opportunity, new List<string>() { Camera.FHAZ, Camera.RHAZ, Camera.NAVCAM, Camera.PANCAM, Camera.MINITES } },
                { Rover.Spirit, new List<string>() { Camera.FHAZ, Camera.RHAZ, Camera.NAVCAM, Camera.PANCAM, Camera.MINITES } }
            };

            _roverLandingDates = new Dictionary<string, DateTime>()
            {
                {Rover.Curiosity, new DateTime(2012, 8, 6, 5, 17, 0, DateTimeKind.Utc) },
                {Rover.Opportunity, new DateTime(2004, 1, 25, 0, 0, 0, DateTimeKind.Utc) },
                {Rover.Spirit, new DateTime(2004, 1, 4, 4, 35, 0, DateTimeKind.Utc) }
            };

            //Initial request object
            _request = initialRequest;
            _request.Camera = _roverCameras.First().Value.First();
            _request.Rover = _roverCameras.Keys.First();
            _request.Sol = 1000;

            _nasaApiCommunicator = nasaApiCommunicator;            
        }

        public event PhotosChangedEventHandler PhotosUpdated;
        // Invoke the Changed event; called whenever list changes
        protected virtual void OnPhotosUpdated(PhotosChangedEventArgs e)
        {
            if (PhotosUpdated != null)
            {
                PhotosUpdated(this, e);
            }
        }
        
        public IReadOnlyDictionary<string, IReadOnlyList<string>> RoverCameras
        {
            get
            {
                return _roverCameras;
            }
        }

        public IReadOnlyDictionary<string, DateTime> RoverLandingDates
        {
            get
            {
                return _roverLandingDates;
            }
        }

        public IRequest Request
        {
            get
            {
                return _request;
            }
        }

        public async void GetPhotos()
        {
            //Cannot use out parameters in async tasks so must return a tuple
            Tuple<bool, IReadOnlyList<Photo>, Error> _apiResult = await _nasaApiCommunicator.GetPhotos(Request.Rover, Request.Camera, Request.Sol);

            if (_apiResult.Item1)
            {
                OnPhotosUpdated(new PhotosChangedEventArgs(_apiResult.Item2, null));
            }
            else
            {
                OnPhotosUpdated(new PhotosChangedEventArgs(null, _apiResult.Item3));
            }
        }
    }
}
