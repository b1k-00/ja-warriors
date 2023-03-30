using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class AvailabilitySummaryDTO
{
    public int DayOfWeek { get; set; }

    public List<AvailabilitySummaryValueDTO> UserCounts { get; set; }

    public AvailabilitySummaryDTO()
    {
        UserCounts = new List<AvailabilitySummaryValueDTO>();
    }
}
