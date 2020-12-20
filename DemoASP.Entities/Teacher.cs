using DomainAbstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("teachers")]
    public class Teacher:DbEntity
    {
        [Column("firstName")]
        [MaxLength(128)]
        [Required]
        public string FirstName { get; set; }
        [Column("lastName")]
        [MaxLength(128)]
        [Required]
        public string LastName { get; set; }
        [Column("middleName")]
        [MaxLength(128)]
        public string MiddleName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<TS> TS { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
