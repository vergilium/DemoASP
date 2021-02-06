using System.Linq;
using DomainRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoASP.WebAPP.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ILogger<TeacherController> _logger;
        private ITeacherRepository _repository;

        public TeacherController(ILogger<TeacherController> logger, ITeacherRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        // GET
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}