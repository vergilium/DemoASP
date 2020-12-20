using DomainContext;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainRepositories
{
    public class MarkRepository : DbRepository<Mark>, IMarkRepository
    {
        public MarkRepository(MyDbContext context) : base(context)
        {
        }
    }
}
