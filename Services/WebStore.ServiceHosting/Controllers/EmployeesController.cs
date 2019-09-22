using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastucture.Interfaces;
using WebStore.ViewModel;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    [Produces("application/Json")]
    public class EmployeesController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _employeeData;

        public EmployeesController(IEmployeesData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpPost, ActionName("Post")]
        public void AddNew(EmployeeView model)
        {
            _employeeData.AddNew(model);
        }

        [NonAction]
        public void Commit()
        {
           _employeeData.Commit();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeData.Delete(id);
        }

        [HttpGet, ActionName("Get")]
        public IEnumerable<EmployeeView> GetAll()
        {
            return _employeeData.GetAll();
        }

        [HttpGet("{id}"), ActionName("Get")]
        public EmployeeView GetById(int id)
        {
            return _employeeData.GetById(id);
        }

        [HttpPut("{id}"), ActionName("Put")]
        public EmployeeView UpDateEmployee(int id, EmployeeView employeeView)
        {
            return _employeeData.UpDateEmployee(id, employeeView);
        }
    }
}