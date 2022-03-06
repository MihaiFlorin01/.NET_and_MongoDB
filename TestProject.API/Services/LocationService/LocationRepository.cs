using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using TestProject.API.Entities;

namespace TestProject.API.Services
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IConfiguration _configuration;
        public MongoClient DbClient { get; set; }

        public LocationRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            DbClient = new MongoClient(_configuration.GetConnectionString("ConnectionString"));
        }

        public IEnumerable<Location> GetLocations()
        {
            var locations = DbClient.GetDatabase("CompanyDB").GetCollection<Location>("Locations").AsQueryable().ToEnumerable<Location>();
            return locations;
        }

        public Location GetLocationById(string locationId)
        {
            var location = DbClient.GetDatabase("CompanyDB").GetCollection<Location>("Locations").Find(l => l.Id == locationId).SingleOrDefault();
            return location;
        }

        public void CreateLocation(Location location)
        {
            if (location != null)
            {
                DbClient.GetDatabase("CompanyDB").GetCollection<Location>("Locations").InsertOne(location);
            }
            else
            {
                throw new ArgumentNullException(nameof(location));
            }
        }

        public void UpdateLocation(string locationId, Location location)
        {
            //var components = DbClient.GetDatabase("CompanyDB").GetCollection<Location>("Locations").AsQueryable().ToEnumerable<Location>();
  
            var filter = Builders<Location>.Filter.Eq(l => l.Id, locationId); ;
            var update = Builders<Location>.Update
                .Set(l => l.LocationName, location.LocationName);

            DbClient.GetDatabase("CompanyDB").GetCollection<Location>("Locations").UpdateOne(filter, update);
        }

        public void DeleteLocation(string locationId)
        {       
            DbClient.GetDatabase("CompanyDB").GetCollection<Location>("Locations").DeleteOne<Location>(l => l.Id == locationId);   
        }
    }
}
