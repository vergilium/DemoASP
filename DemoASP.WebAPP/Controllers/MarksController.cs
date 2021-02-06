using DomainRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoASP.WebAPP.Controllers
{
    public class MarksController : Controller
    {
        private readonly IMarkRepository _repository;

        public MarksController(IMarkRepository repository)
        {
            _repository = repository;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Add(int? studentId, int? mark, int? subject, int? teacher)
        {
            if (studentId != null && mark != null && subject != null && teacher != null)
            {
                await _repository.AddItemAsync(
                    new Entities.Mark
                    {
                        StudentId = studentId.Value,
                        SubjectId = subject.Value,
                        TeacherId = teacher.Value,
                        Value = mark.Value
                    });
            }
            return RedirectToAction("Show", "Students", new {id = studentId});
        }
    }
}
