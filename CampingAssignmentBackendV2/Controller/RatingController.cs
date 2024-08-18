using Microsoft.AspNetCore.Mvc;
using CampingAssignmentBackendV2.Data;
using System.Collections.Generic;

namespace CampingAssignmentBackendV2.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public RatingController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Get all Ratings
        [HttpGet]
        public ActionResult<IEnumerable<Rating>> GetRatings()
        {
            return Ok(_data.GetRatings());
        }

        // Create a new Rating
        [HttpPost]
        public ActionResult Post(Rating rating)
        {
            _data.AddRating(rating);
            return Ok("Rating created");
        }

        // Get a Rating by Id
        [HttpGet("{id}")]
        public ActionResult<Rating> GetRating(int id)
        {
            var rating = _data.GetRatingById(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }

        // Get Ratings by User Id
        [HttpGet("byUserId/{userId}")]
        public ActionResult<IEnumerable<Rating>> GetRatingsByUserId(int userId)
        {
            return Ok(_data.GetRatingsByUserId(userId));
        }

        // Update a Rating
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Rating rating)
        {
            var existingRating = _data.GetRatingById(id);
            if (existingRating == null)
            {
                return NotFound();
            }
            _data.UpdateRating(id, rating.CampingSpotId, rating.UserId, rating.Score);
            return Ok("Rating updated");
        }

        // Delete a Rating by Id
        [HttpDelete("{id}")]
        public ActionResult DeleteRating(int id)
        {
            _data.DeleteRating(id);
            return Ok("Rating deleted");
        }
    }
}
