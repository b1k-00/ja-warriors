using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO;
public class AvailabilitySummaryDTO
{
    public int DayOfWeek { get; set; }

    public List<AvailabilitySummaryValueDTO> Summaries { get; set; }

    public AvailabilitySummaryDTO()
    {
        Summaries = new List<AvailabilitySummaryValueDTO>();
    }
}
