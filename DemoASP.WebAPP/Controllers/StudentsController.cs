using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoASP.WebAPP.Models;
using DomainRepositories;
using DemoASP.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoASP.WebAPP.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ILogger<StudentsController> _logger;
        private IStudentRepository _repository;

        public StudentsController(ILogger<StudentsController> logger, IStudentRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult List()
        {
            return View(_repository
                .AllItems
                .Include(s=>s.Group)
                .ThenInclude(g=>g.Faculty)
                .Select(s=>new StudentVM(s)));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
