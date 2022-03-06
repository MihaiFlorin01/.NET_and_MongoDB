using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using TestProject.API.Entities;

namespace TestProject.API.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IConfiguration _configuration;
        public MongoClient DbClient { get; set; }

        public DepartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            DbClient = new MongoClient(_configuration.GetConnectionString("ConnectionString"));
        }

        public JsonResult GetDepartments()
        {
            var departments = DbClient.GetDatabase("CompanyDB").GetCollection<Department>("Departments").AsQueryable();
            return new JsonResult(departments);
        }

        public JsonResult GetDepartmentById(string departmentId)
        {
            if (departmentId != null)
            {
                var department = DbClient.GetDatabase("CompanyDB").GetCollection<Department>("Departments").Find(d => d.Id == departmentId);
                return new JsonResult(department);
            }
            else
            {
                return new JsonResult(null);
            }
        }

        public JsonResult GetDepartmentByName(string departmentName)
        {
            var department = DbClient.GetDatabase("CompanyDB").GetCollection<Department>("Departments").Find(d => d.DepartmentName == departmentName);
            if (department != null)
            {
                return new JsonResult(department);
            }
            else
            {
                return new JsonResult(null);
            }
        }

        public void CreateDepartment(Department department)
        {
            if (department != null)
            {
                DbClient.GetDatabase("CompanyDB").GetCollection<Department>("Departments").InsertOne(department);
            }
            else
            {
                throw new ArgumentNullException(nameof(department));
            }
        }

        public void UpdateDepartment(Department department)
        {
            if (department != null)
            {
                // No code in this implementation
                // DbClient.GetDatabase("CompanyDB").GetCollection<Location>("Locations").UpdateOne(location);
            }
            else
            {
                throw new ArgumentNullException(nameof(department));
            }
        }

        public void DeleteDepartment(string departmentId)
        {
            if (departmentId != null)
            {
                DbClient.GetDatabase("CompanyDB").GetCollection<Department>("Departments").DeleteOne(departmentId);
            }
            else
            {
                throw new ArgumentNullException(nameof(departmentId));
            }
        }
    }
}
