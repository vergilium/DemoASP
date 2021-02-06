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
            Subjects = s.Group.Faculty.Subjects?.Select(
                subj => new Subject
                {
                    Id = subj.Id,
                    Name = subj.Name
                  //  Teachers = (List<Teacher>) subj.Teachers.Select( t => new Teacher
                  //  {
                  //      Id = t.Id,
                  //      FirstName = t.FirstName,
                  //      LastName = t.LastName,
                  //      MiddleName = t.MiddleName
                  //  }).ToList()
                }).ToList();
            var marks = s.Marks?.Select(m => m.Value).ToArray();
            if(marks!=null) Marks.AddRange(marks);
        }

        public static implicit operator Student(StudentVM viewModel)
        {
            return new Student
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                MiddleName = viewModel.MiddleName,
                GroupId = viewModel.GroupId
            };
        }
       

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string GroupName { get; set; }
        public int GroupId { get; set; }
        public string FacultyName { get; set; }
        public List<Subject> Subjects{ get; } = new List<Subject>();
        public List<int> Marks { get; } = new List<int>();
        
    }
}
