using DomainContext;
using Entities;

namespace DomainRepositories
{
    public class TeacherRepository: DbRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(MyDbContext context) : base(context)
        {
        }
    }
}