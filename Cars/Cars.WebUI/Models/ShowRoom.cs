﻿using System.Collections.Generic;
using Cars.Domain.Entities;

namespace Cars.WebUI.Models
{
    public class ShowRoom
    {
        public IEnumerable<Car> Cars { get; set; }
        public string CurrentMark { get; set; }
    }
}