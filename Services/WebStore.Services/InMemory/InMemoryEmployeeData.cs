using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastucture.Interfaces;
using WebStore.ViewModel;

namespace WebStore.Infrastucture.Implementations
{
    public class InMemoryEmployeeData : IEmployeesData
    {
        private readonly List<EmployeeView> _employees;

        public InMemoryEmployeeData()
        {
            _employees = new List<EmployeeView>
            {
                new EmployeeView
                {
                    Id=1,
                    FirstName="Петр",
                    SurName="Петров",
                    Age=32
                },

                new EmployeeView
                {
                    Id=2,
                    FirstName="Иван",
                    SurName="Иванов",
                    Age=62
                }
            };
        }

        public void AddNew(EmployeeView model)
        {
            model.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(model);
        }

        public void Commit()
        {
            
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }

        public IEnumerable<EmployeeView> GetAll()
        {
            return _employees;
        }

        public EmployeeView GetById(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }

        public EmployeeView UpDateEmployee(int id, EmployeeView employeeView)
        {
            if (employeeView is null)
                throw new ArgumentNullException(nameof(employeeView));

            var db_employee = GetById(id);

            if (db_employee is null)
                throw new InvalidOperationException($"Сотрудник с Id:{id} не найден");

            db_employee.Age = employeeView.Age;
            db_employee.FirstName = employeeView.FirstName;
            db_employee.Id = employeeView.Id;
            db_employee.SurName = employeeView.SurName;

            return db_employee;
        }
    }
}
