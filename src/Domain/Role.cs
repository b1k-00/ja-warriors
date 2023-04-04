using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class Role
{
    //public ICollection<User> Users { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
}
