using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using TestProject.API.Entities;
using TestProject.API.Models;
using TestProject.API.Services;

namespace TestProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationsController(ILocationRepository locationsRepository, IMapper mapper)
        {
            _locationRepository = locationsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetLocations()
        {
            return Ok(_locationRepository.GetLocations());
        }

        [HttpGet("{locationId}", Name = "GetLocationById")]
        public ActionResult<Location> GetLocationById(string locationId)
        {
            var location = _locationRepository.GetLocationById(locationId);
            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);

        }

        [HttpPost]
        public ActionResult<Location> CreateLocation([FromBody] LocationForCreation locationForCreation)
        {
            var location = _mapper.Map<Location>(locationForCreation);

            _locationRepository.CreateLocation(location);

            return CreatedAtRoute("GetLocationById", new { locationId = location.Id }, location);
        }

        [HttpPut("{locationId}")]
        public ActionResult<Location> UpdateLocation(string locationId, [FromBody] LocationForUpdate locationForUpdate)
        {
            var location = _mapper.Map<Location>(locationForUpdate);
            if (location == null)
            {
                return NotFound();
            }
            _locationRepository.UpdateLocation(locationId, location);

            return NoContent();
        }

        [HttpDelete("{locationId}")]
        public ActionResult<Location> DeleteLocation(string locationId)
        {
            _locationRepository.DeleteLocation(locationId);

            return NoContent();
        }
    }
}
