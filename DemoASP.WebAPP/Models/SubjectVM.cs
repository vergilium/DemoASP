using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DemoASP.WebAPP.Models
{
    public class SubjectVM
    {
        public SubjectVM(){}

        public SubjectVM(Subject model)
        {
            Name = model.Name;
            Teachers = model.Teachers?.Select(
                t => new Teacher
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    MiddleName = t.MiddleName
                }).ToList();
            Faculties = model.Faculties?.Select(
                f => new Faculty
                {
                    Id = f.Id,
                    Name = f.Name
                }).ToList();
        }
        
        
        public int Id { get; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; }
        public List<Faculty> Faculties { get; }
    }
}