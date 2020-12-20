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
    [Table("departmens")]
    public class Department:DbEntity
    {
        [Column("name")]
        [MaxLength(32)]
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
