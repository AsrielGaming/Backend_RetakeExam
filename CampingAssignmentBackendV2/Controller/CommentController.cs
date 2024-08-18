using Microsoft.AspNetCore.Mvc;
using CampingAssignmentBackendV2.Data;
using System.Collections.Generic;

namespace CampingAssignmentBackendV2.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public CommentController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Get all Comments
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetComments()
        {
            return Ok(_data.GetComments());
        }

        // Create a new Comment
        [HttpPost]
        public ActionResult Post(Comment comment)
        {
            _data.AddComment(comment);
            return Ok("Comment created");
        }

        // Get a Comment by Id
        [HttpGet("{id}")]
        public ActionResult<Comment> GetComment(int id)
        {
            var comment = _data.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        // Get Comments by User Id
        [HttpGet("byUserId/{userId}")]
        public ActionResult<IEnumerable<Comment>> GetCommentsByUserId(int userId)
        {
            return Ok(_data.GetCommentsByUserId(userId));
        }

        // Update a Comment
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Comment comment)
        {
            var existingComment = _data.GetCommentById(id);
            if (existingComment == null)
            {
                return NotFound();
            }
            _data.UpdateComment(id, comment.CampingSpotId, comment.UserId, comment.Text);
            return Ok("Comment updated");
        }

        // Delete a Comment by Id
        [HttpDelete("{id}")]
        public ActionResult DeleteComment(int id)
        {
            _data.DeleteComment(id);
            return Ok("Comment deleted");
        }
    }
}
