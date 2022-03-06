using Microsoft.AspNetCore.Mvc;
using TestProject.API.Entities;

namespace TestProject.API.Services
{
    public interface IJobRepository
    {
        JsonResult GetJobs();
        JsonResult GetJobById(string jobId);
        JsonResult GetJobByName(string jobName);
        void CreateJob(Job job);
        void UpdateJob(Job job);
        void DeleteJob(string job);
    }
}
