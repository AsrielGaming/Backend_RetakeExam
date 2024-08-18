using Microsoft.AspNetCore.Mvc;
using CampingAssignmentBackendV2.Data;
using System.Collections.Generic;

namespace CampingAssignmentBackendV2.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public BookingController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        // Get all Bookings
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings()
        {
            return Ok(_data.GetBookings());
        }

        // Create a new Booking
        [HttpPost]
        public ActionResult Post(Booking booking)
        {
            _data.AddBooking(booking);
            return Ok("Booking created");
        }

        // Get a Booking by Id
        [HttpGet("{id}")]
        public ActionResult<Booking> GetBooking(int id)
        {
            var booking = _data.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        // Get Bookings by UserId
        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<Booking>> GetBookingsByUserId(int userId)
        {
            var bookings = _data.GetBookingsByUserId(userId);
            if (bookings == null)
            {
                return NotFound();
            }
            return Ok(bookings);
        }

        // Update a Booking
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Booking booking)
        {
            var existingBooking = _data.GetBookingById(id);
            if (existingBooking == null)
            {
                return NotFound();
            }
            _data.UpdateBooking(id, booking.UserId, booking.SpotId, booking.StartDate, booking.EndDate, booking.TotalPrice);
            return Ok("Booking updated");
        }

        // Delete a Booking by Id
        [HttpDelete("{id}")]
        public ActionResult DeleteBooking(int id)
        {
            _data.DeleteBooking(id);
            return Ok("Booking deleted");
        }
    }
}
