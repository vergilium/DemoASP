using DomainAbstractions;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    [Table("marks")]
    public class Mark:DbEntity
    {
        [Column("mark")]
        public int Value { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
