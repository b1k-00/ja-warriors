﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class Availability
{
    public int Id { get; set; }

    public string startTime { get; set; }
    public string EndTime { get; set; }

    public int? DayOfTheWeek { get; set; }

}
