using DomainContext;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainRepositories
{
    public class FacultyRepository : DbRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(MyDbContext context) : base(context)
        {
        }
    }
}
