using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departments = new List<Department>();
            departments.Add(new Department { Id = 001, Name = "Eletronics"});
            departments.Add(new Department { Id = 002, Name = "Clothes" });
            departments.Add(new Department { Id = 003, Name = "Furniture" });
            departments.Add(new Department { Id = 004, Name = "Office Supplies" });
            departments.Add(new Department { Id = 005, Name = "Tools" });

            return View(departments);
        }
    }
}
