using MVCLearning.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCLearning.ViewModels;
using MVCLearning.Views.Home;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MVCLearning.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment hostingEnviroment;

        public HomeController(IEmployeeRepository employeeRepository, IWebHostEnvironment hostingEnviroment)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnviroment = hostingEnviroment;
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
        public ActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid) {
                string uniqueFileName = ProcessUploadedFile(model);

            Employee newEmployee = new Employee
            {
                Name = model.Name,
                Email = model.Email,
                Department = model.Department,
                Photo = uniqueFileName
            };
        

                _employeeRepository.AddEmployee(newEmployee);
            return RedirectToAction("Details", new { id = newEmployee.Id });
            }
                return View();
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //find the user
            Employee employee = _employeeRepository.GetEmployee(id);
            //add the users details to the view model instance
            EmployeeEditViewModel employeeVM = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.Photo
            };


            return View(employeeVM);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                if(model.Photos != null) { 
                string uniqueFileName = ProcessUploadedFile(model);
                    if(model.ExistingPhotoPath != null)
                    {
                        string filepath = Path.Combine(hostingEnviroment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filepath);
                    }
                    employee.Photo = uniqueFileName;
                }

                _employeeRepository.Update(employee);
                return RedirectToAction("Details", new { id = employee.Id });
            }
            return View();
        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photos != null)
            {
                //get the folder you want to save the file into using the iwebhosteviroment service
                string uploadFolder = Path.Combine(hostingEnviroment.WebRootPath, "Images");
                //create a unique name for the file
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photos.FileName;
                //upload the file into the db
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create)) { 
                model.Photos.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
        
 }