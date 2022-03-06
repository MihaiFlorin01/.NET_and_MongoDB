using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using TestProject.API.Entities;

namespace TestProject.API.Services
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetLocations();
        Location GetLocationById(string locationId);
        void CreateLocation(Location location);
        void UpdateLocation(string locationId, Location location);
        void DeleteLocation(string locationId);
    }
}