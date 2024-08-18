using Microsoft.AspNetCore.Mvc;
using CampingAssignmentBackendV2.Data;

namespace CampingAssignmentBackendV2.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public UserController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // User methodes
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_data.GetUsers());
        }

        [HttpPost]
        public ActionResult Post(User user)
        {
            _data.AddUser(user);
            return Ok("User created");
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _data.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // Update a User
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            var existingUser = _data.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            _data.UpdateUser(id, user.Username, user.Password, user.Email);
            return Ok("User updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            _data.DeleteUser(id);
            return Ok("User deleted");
        }
    }
}