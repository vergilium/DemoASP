﻿using System;
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
                .Include(s => s.Group)
                .ThenInclude(g => g.Faculty)
                .ThenInclude(s => s.Subjects)
                .Select(s => new StudentVM(s)));
        }
        
        public IActionResult Show(int? id)
        {
            if (id.HasValue)
            {
                var stud = _repository
                .AllItems
                .Include(s => s.Marks)
                .Include(s => s.Group)
                .ThenInclude(g => g.Faculty)   
                .ThenInclude(s => s.Subjects)
                .ThenInclude(t => t.Teachers)
                .FirstOrDefault(s => s.Id == id.Value);
                
                if (stud != null)
                {
                    return View(new StudentVM(stud));
                }
            }
            return RedirectToAction("Error");

        }

        [Microsoft.AspNetCore.Authorization.Authorize(Policy = "RequireAdministrator")]
        public async Task<IActionResult> Add(StudentVM stud)
        {
            await _repository.AddItemAsync(stud);
            return RedirectToAction("List");
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
