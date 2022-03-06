using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using TestProject.API.Entities;

namespace TestProject.API.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;
        public MongoClient DbClient { get; set; }

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            DbClient = new MongoClient(_configuration.GetConnectionString("ConnectionString"));
        }

        public JsonResult GetEmployees()
        {
            var departments = DbClient.GetDatabase("CompanyDB").GetCollection<Employee>("Employees").AsQueryable();
            return new JsonResult(departments);
        }

        public JsonResult GetEmployeeById(string employeeId)
        {
            if (employeeId != null)
            {
                var employee = DbClient.GetDatabase("CompanyDB").GetCollection<Employee>("Employees").Find(e => e.Id == employeeId);
                return new JsonResult(employee);
            }
            else
            {
                return new JsonResult(null);
            }
        }

        public JsonResult GetEmployeeByName(string employeeName)
        {
            if (employeeName != null)
            {
                var employee = DbClient.GetDatabase("CompanyDB").GetCollection<Employee>("Employees").Find(e => e.EmployeeName == employeeName);
                return new JsonResult(employee);
            }
            else
            {
                return new JsonResult(null);
            }
        }
      
        public void CreateEmployee(Employee employee)
        {
            if (employee != null)
            {
                DbClient.GetDatabase("CompanyDB").GetCollection<Employee>("Employees").InsertOne(employee);
            }
            else
            {
                throw new ArgumentNullException(nameof(employee));
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee != null)
            {
                // No code in this implementation
                // DbClient.GetDatabase("CompanyDB").GetCollection<Location>("Locations").UpdateOne(location);
            }
            else
            {
                throw new ArgumentNullException(nameof(employee));
            }
        }

        public void DeleteEmployee(string employeeId)
        {
            if (employeeId != null)
            {
                DbClient.GetDatabase("CompanyDB").GetCollection<Employee>("Employees").DeleteOne(employeeId);
            }
            else
            {
                throw new ArgumentNullException(nameof(employeeId));
            }
        }
    }
}
