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
    [Table("subjects")]
    public class Subject:DbEntity
    {
        [Column("name")]
        [MaxLength(128)]
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<TS> TS { get; set; }
        public List<Mark> Marks { get; set; }
        public List<Faculty> Faculties { get; set; }
        public List<FS> FS { get; set; }
        
    }
}
