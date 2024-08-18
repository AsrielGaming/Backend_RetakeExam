using Microsoft.AspNetCore.Mvc;
using CampingAssignmentBackendV2.Data;
using System.Collections.Generic;

namespace CampingAssignmentBackendV2.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CampingSpotController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public CampingSpotController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Get all CampingSpots
        [HttpGet]
        public ActionResult<IEnumerable<CampingSpot>> GetCampingSpots()
        {
            return Ok(_data.GetCampingSpots());
        }

        // Create a new CampingSpot
        [HttpPost]
        public ActionResult Post(CampingSpot campingSpot)
        {
            _data.AddCampingSpot(campingSpot);
            return Ok("Camping spot created");
        }

        // Get a CampingSpot by Id
        [HttpGet("{id}")]
        public ActionResult<CampingSpot> GetCampingSpot(int id)
        {
            var campingSpot = _data.GetCampingSpotById(id);
            if (campingSpot == null)
            {
                return NotFound();
            }
            return Ok(campingSpot);
        }

        // Get Camping Spots by Camping Ground Id
        [HttpGet("byCampingGroundId/{campingGroundId}")]
        public ActionResult<IEnumerable<CampingSpot>> GetCampingSpotsByCampingGroundId(int campingGroundId)
        {
            return Ok(_data.GetCampingSpotsByCampingGroundId(campingGroundId));
        }

        // Update a Camping Spot
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CampingSpot campingSpot)
        {
            var existingCampingSpot = _data.GetCampingSpotById(id);
            if (existingCampingSpot == null)
            {
                return NotFound();
            }
            _data.UpdateCampingSpot(id, campingSpot.SpotName, campingSpot.Size, campingSpot.Description, campingSpot.Price, campingSpot.IsAvailable, campingSpot.UserId, campingSpot.CampingGroundId, campingSpot.Amenities, campingSpot.CampTypes);
            return Ok("Camping Spot updated");
        }

        // Delete a CampingSpot by Id
        [HttpDelete("{id}")]
        public ActionResult DeleteCampingSpot(int id)
        {
            _data.DeleteCampingSpot(id);
            return Ok("Camping spot deleted");
        }
    }
}
