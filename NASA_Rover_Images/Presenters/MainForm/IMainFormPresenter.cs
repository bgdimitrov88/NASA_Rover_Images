using System;
using NASA_Rover_Images.Models;
using System.Collections.Generic;

namespace NASA_Rover_Images.Presenters.MainForm
{
    public interface IMainFormPresenter
    {
        void GetPhotos();

        IReadOnlyDictionary<string, IReadOnlyList<string>> RoverCameras { get; }

        IReadOnlyDictionary<string, DateTime> RoverLandingDates { get; }

        IRequest Request { get; }

        event PhotosChangedEventHandler PhotosUpdated;
    }
}
