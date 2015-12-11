using NASA_Rover_Images.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_Rover_Images.Views
{
    public interface IMainView
    {
        void ShowPhotos(IReadOnlyList<Photo> photos);

        void ShowError(Error error);
    }
}
