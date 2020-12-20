using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("teacher_subject")]
    public class TS
    {
        [Column("teacherId")]
        public int TeacherId { get; set; }
        [Column("subjectId")]
        public int SubjectId { get; set; }
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}
