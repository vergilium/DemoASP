using DomainAbstractions;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainRepositories
{
    public interface IFacultyRepository:IDbRepository<Faculty>
    {
    }
    public interface IGroupRepository : IDbRepository<Group>
    {
    }
    public interface IStudentRepository : IDbRepository<Student>
    {
    }
}
