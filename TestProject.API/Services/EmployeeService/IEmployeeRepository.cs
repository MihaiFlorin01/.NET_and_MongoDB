using Microsoft.AspNetCore.Mvc;
using TestProject.API.Entities;

namespace TestProject.API.Services
{
    public interface IEmployeeRepository
    {
        JsonResult GetEmployees();
        JsonResult GetEmployeeById(string employeeId);
        JsonResult GetEmployeeByName(string employeeName);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(string employeeId);
    }
}
