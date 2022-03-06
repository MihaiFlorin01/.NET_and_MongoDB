using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using TestProject.API.Entities;

namespace TestProject.API.Services
{
    public class JobRepository : IJobRepository
    {
        private readonly IConfiguration _configuration;
        public MongoClient DbClient { get; set; }

        public JobRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            DbClient = new MongoClient(_configuration.GetConnectionString("ConnectionString"));
        }

        public JsonResult GetJobs()
        {
            var jobs = DbClient.GetDatabase("CompanyDB").GetCollection<Location>("Jobs").AsQueryable();
            return new JsonResult(jobs);
        }

        public JsonResult GetJobById(string jobId)
        {
            if (jobId != null)
            {
                var job = DbClient.GetDatabase("CompanyDB").GetCollection<Job>("Jobs").Find(j => j.Id == jobId);
                return new JsonResult(job);
            }
            else
            {
                return new JsonResult(null);
            }
        }

        public JsonResult GetJobByName(string jobName)
        {
            var job = DbClient.GetDatabase("CompanyDB").GetCollection<Job>("Jobs").Find(j => j.JobName == jobName);
            if (job != null)
            {
                return new JsonResult(job);
            }
            else
            {
                return new JsonResult(null);
            }
        }

        public void CreateJob(Job job)
        {
            if (job != null)
            {
                DbClient.GetDatabase("CompanyDB").GetCollection<Job>("Jobs").InsertOne(job);
            }
            else
            {
                throw new ArgumentNullException(nameof(job));
            }
        }    

        public void UpdateJob(Job job)
        {
            if (job != null)
            {
                // No code in this implementation
                // DbClient.GetDatabase("CompanyDB").GetCollection<Location>("Locations").UpdateOne(location);
            }
            else
            {
                throw new ArgumentNullException(nameof(job));
            }
        }

        public void DeleteJob(string jobId)
        {
            if (jobId != null)
            {
                DbClient.GetDatabase("CompanyDB").GetCollection<Job>("Jobs").DeleteOne(jobId);
            }
            else
            {
                throw new ArgumentNullException(nameof(jobId));
            }
        }
    }
}
