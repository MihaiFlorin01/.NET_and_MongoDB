using Microsoft.AspNetCore.Mvc;
using TestProject.API.Entities;

namespace TestProject.API.Services
{
    public interface IDepartmentRepository
    {
        JsonResult GetDepartments();
        JsonResult GetDepartmentById(string departmentId);
        JsonResult GetDepartmentByName(string departmentName);
        void CreateDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(string departmentId);
    }
}
