using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_Rover_Images.Models
{
    public interface IRequest
    {
        string Rover { get; set; }

        string Camera { get; set; }

        int Sol { get; set; }
    }
}
