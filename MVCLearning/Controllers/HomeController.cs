using MVCLearning.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCLearning.ViewModels;

namespace MVCLearning.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ActionResult Index()
        {
           return View("emplList", _employeeRepository.GetAllEmployees());
        }

        public ActionResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Details View"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee empl)
        { 
            Employee employee = _employeeRepository.AddEmployee(empl);
            return RedirectToAction("Details", new { id = employee.Id });
        }
        
    }
}
