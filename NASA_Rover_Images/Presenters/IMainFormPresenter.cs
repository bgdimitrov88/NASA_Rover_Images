using NASA_Rover_Images.Models;
using System.Collections.Generic;
namespace NASA_Rover_Images
{
    public interface IMainFormPresenter
    {
        void GetImages();

        IReadOnlyDictionary<string, IReadOnlyList<string>> Rovers { get; }

        IRequest Request { get; }
    }
}
