using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class Availability : BaseEntity
{

    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }

    public int? DayOfTheWeek { get; set; }

}
