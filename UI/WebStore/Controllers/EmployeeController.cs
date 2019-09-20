using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastucture.Interfaces;
using WebStore.ViewModel;

namespace WebStore.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeesData _employees;

        public EmployeeController(IEmployeesData employees)
        {
            _employees = employees;
        }

        public IActionResult Index()
        {
            return View(_employees.GetAll());
        }

        public IActionResult Details(int id)
        {
            var employee = _employees.GetById(id);

            if (ReferenceEquals(employee,null))
                return NotFound();

            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new EmployeeView());

            EmployeeView model = _employees.GetById(id.Value);

            if (model==null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeView model)
        {
            if (model.Id > 0)
            {
                var dbItem = _employees.GetById(model.Id);

                if (ReferenceEquals(dbItem,null)) // Сравниваем dbItem и null
                    return NotFound();

                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Age = model.Age;
            }
            else
                _employees.AddNew(model);

            _employees.Commit();// для добавления в базу данных

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _employees.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}