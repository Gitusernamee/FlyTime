﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Models
{
    public class Aeroport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string Country { get; set; } = string.Empty;
    }
}
