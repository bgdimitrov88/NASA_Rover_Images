﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_Rover_Images.Models
{
    public class Request : IRequest
    {
        public string Camera { get; set; }

        public string Rover { get; set; }

        public int Sol { get; set; }
    }
}
