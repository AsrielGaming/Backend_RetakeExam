using Microsoft.AspNetCore.Mvc;
using CampingAssignmentBackendV2.Data;
using System.Collections.Generic;

namespace CampingAssignmentBackendV2.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CamptypeController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public CamptypeController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Get all Camptypes
        [HttpGet]
        public ActionResult<IEnumerable<Camptype>> GetCamptypes()
        {
            return Ok(_data.GetCamptypes());
        }

        // Create a new Camptype
        [HttpPost]
        public ActionResult Post(Camptype camptype)
        {
            _data.AddCamptype(camptype);
            return Ok("Camptype created");
        }

        // Get a Camptype by Id
        [HttpGet("{id}")]
        public ActionResult<Camptype> GetCamptype(int id)
        {
            var camptype = _data.GetCamptypeById(id);
            if (camptype == null)
            {
                return NotFound();
            }
            return Ok(camptype);
        }

        // Update a Camptype
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Camptype camptype)
        {
            var existingCamptype = _data.GetCamptypeById(id);
            if (existingCamptype == null)
            {
                return NotFound();
            }
            _data.UpdateCamptype(id, camptype.TypeName);
            return Ok("Camptype updated");
        }

        // Delete a Camptype by Id
        [HttpDelete("{id}")]
        public ActionResult DeleteCamptype(int id)
        {
            _data.DeleteCamptype(id);
            return Ok("Camptype deleted");
        }
    }
}
