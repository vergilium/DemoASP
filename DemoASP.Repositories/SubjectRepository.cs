using DomainContext;
using Entities;

namespace DomainRepositories
{
    public class SubjectRepository: DbRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(MyDbContext context) : base(context)
        {
        }
    }
}