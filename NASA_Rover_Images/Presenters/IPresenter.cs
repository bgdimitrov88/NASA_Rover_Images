using NASA_Rover_Images.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_Rover_Images
{
    public interface IPresenter
    {
        void GetImages();

        IReadOnlyDictionary<string, IReadOnlyList<string>> Rovers { get; }

        IRequest Request { get; }
    }
}
