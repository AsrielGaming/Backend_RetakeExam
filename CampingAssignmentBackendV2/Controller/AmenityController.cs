using Microsoft.AspNetCore.Mvc;
using CampingAssignmentBackendV2.Data;
using System.Collections.Generic;

namespace CampingAssignmentBackendV2.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AmenityController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public AmenityController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Get all Amenities
        [HttpGet]
        public ActionResult<IEnumerable<Amenity>> GetAmenities()
        {
            return Ok(_data.GetAmenities());
        }

        // Create a new Amenity
        [HttpPost]
        public ActionResult Post(Amenity amenity)
        {
            _data.AddAmenity(amenity);
            return Ok("Amenity created");
        }

        // Get an Amenity by Id
        [HttpGet("{id}")]
        public ActionResult<Amenity> GetAmenity(int id)
        {
            var amenity = _data.GetAmenityById(id);
            if (amenity == null)
            {
                return NotFound();
            }
            return Ok(amenity);
        }

        // Update an Amenity by Id
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Amenity amenity)
        {
            var existingAmenity = _data.GetAmenityById(id);
            if (existingAmenity == null)
            {
                return NotFound();
            }

            _data.UpdateAmenity(id, amenity.Name);
            return Ok("Amenity updated");
        }

        // Delete an Amenity by Id
        [HttpDelete("{id}")]
        public ActionResult DeleteAmenity(int id)
        {
            _data.DeleteAmenity(id);
            return Ok("Amenity deleted");
        }
    }
}
