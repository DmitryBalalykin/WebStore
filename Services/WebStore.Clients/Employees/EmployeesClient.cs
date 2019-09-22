using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.Infrastucture.Interfaces;
using WebStore.ViewModel;

namespace WebStore.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        public EmployeesClient(IConfiguration configuration) : base(configuration, "api/Employees") { }

        public void AddNew(EmployeeView model)
        {
            Post(_ServiceAddress, model);
        }

        public void Commit()
        {
        }

        public void Delete(int id)
        {
            Delete($"{_ServiceAddress}/{id}");
        }

        public IEnumerable<EmployeeView> GetAll()
        {
            return Get<List<EmployeeView>>(_ServiceAddress);
        }

        public EmployeeView GetById(int id)
        {
            return Get<EmployeeView>($"{_ServiceAddress}/{id}");
        }

        public EmployeeView UpDateEmployee(int id, EmployeeView employeeView)
        {
            var response = Put($"{_ServiceAddress}/{id}", employeeView);
            return response.Content.ReadAsAsync<EmployeeView>().Result;
        }
    }
}
