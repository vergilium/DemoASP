using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoASP.WebAPP.Models;
using DomainRepositories;
using DemoASP.Models;
using Entities;
using Microsoft.EntityFrameworkCore;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace DemoASP.WebAPP.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ILogger<SubjectController> _logger;
        private ISubjectRepository _repository;

        public SubjectController(ILogger<SubjectController> logger, ISubjectRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public JsonResult List(int subject)
        {
            return Json(_repository
                .AllItems
                .Include(s => s.Teachers)
                .Where(s => s.Id == subject)
                .ToList()
            );
        }
    }
}
