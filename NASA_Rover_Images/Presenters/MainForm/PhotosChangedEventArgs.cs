using NASA_Rover_Images.Models;
using System;
using System.Collections.Generic;

namespace NASA_Rover_Images.Presenters.MainForm
{
    public class PhotosChangedEventArgs : EventArgs
    {
        public PhotosChangedEventArgs(IReadOnlyList<Photo> photos, Error error)
        {
            Photos = photos;
            Error = error;
        }

        public IReadOnlyList<Photo> Photos { get; private set; }
        public Error Error { get; private set; }
    }
}
