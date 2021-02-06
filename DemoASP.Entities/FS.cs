using DomainAbstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table(name:"faculty_subject")]
    public class FS
    {
        [Column(name:"faculty_id")]
        public int facultyId { get; set; }
        [Column(name:"subject_id")]
        public int subjectId { get; set; }
        public Faculty Faculty { get; set; }
        public Subject Subject { get; set; }
    }
}