using NASA_Rover_Images.Models;
using System.Collections.Generic;

namespace NASA_Rover_Images.Presenters.MainForm
{
    public interface IMainFormPresenter
    {
        void GetPhotos();

        IReadOnlyDictionary<string, IReadOnlyList<string>> Rovers { get; }

        IRequest Request { get; }

        event PhotosChangedEventHandler PhotosUpdated;
    }
}
