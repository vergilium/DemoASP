using DomainRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add(int? studentId, int? mark)
        {
            if (studentId != null)
            {
                if (mark != null)
                    await _repository.AddItemAsync(
                        new Entities.Mark
                        {
                            StudentId = studentId.Value,
                            Value = mark.Value
                        });
                
            }
            return RedirectToAction("Show", "Students", new {id = studentId});
        }
    }
}
