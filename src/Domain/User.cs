using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User : BaseEntity
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool? Graduated { get; set; }
        public DateTime? GraduatedDate { get; set; }
        public int? RoleId { get; set; }
        public int Id { get; set; }
        public int DesignStudiosId { get; set; }
        public Guid? AwsId { get; set; }
        [NotMapped]
        public bool IsManager { get; set; }
    }
}
