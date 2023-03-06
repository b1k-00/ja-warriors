using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class Meeting
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; } 
}
