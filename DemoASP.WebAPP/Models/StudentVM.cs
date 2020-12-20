using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoASP.Models
{
    public class StudentVM
    {
        public StudentVM()
        {

        }
        public StudentVM(Student s)
        {
            Id = s.Id;
            FirstName = s.FirstName;
            LastName = s.LastName;
            MiddleName = s.MiddleName;
            GroupName = s.Group.Name;
            FacultyName = s.Group.Faculty.Name;            
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GroupName { get; set; }
        public string FacultyName { get; set; }
        public List<int> Marks { get; } = new List<int>();
        public string MiddleName { get; internal set; }
    }
}
