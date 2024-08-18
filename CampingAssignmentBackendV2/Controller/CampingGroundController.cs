using Microsoft.AspNetCore.Mvc;
using CampingAssignmentBackendV2.Data;
using System.Collections.Generic;

namespace CampingAssignmentBackendV2.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CampingGroundController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public CampingGroundController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Get all CampingGrounds
        [HttpGet]
        public ActionResult<IEnumerable<CampingGround>> GetCampingGrounds()
        {
            return Ok(_data.GetCampingGrounds());
        }

        // Create a new CampingGround
        [HttpPost]
        public ActionResult Post(CampingGround campingGround)
        {
            _data.AddCampingGround(campingGround);
            return Ok("Camping ground created");
        }

        // Get a CampingGround by Id
        [HttpGet("{id}")]
        public ActionResult<CampingGround> GetCampingGround(int id)
        {
            var campingGround = _data.GetCampingGroundById(id);
            if (campingGround == null)
            {
                return NotFound();
            }
            return Ok(campingGround);
        }

        // Update a Camping Ground
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CampingGround campingGround)
        {
            var existingCampingGround = _data.GetCampingGroundById(id);
            if (existingCampingGround == null)
            {
                return NotFound();
            }
            _data.UpdateCampingGround(id, campingGround.Name, campingGround.AmountOfCampingSpots, campingGround.Location, campingGround.IsPetFriendly);
            return Ok("Camping Ground updated");
        }

        // Delete a CampingGround by Id
        [HttpDelete("{id}")]
        public ActionResult DeleteCampingGround(int id)
        {
            _data.DeleteCampingGround(id);
            return Ok("Camping ground deleted");
        }
    }
}
