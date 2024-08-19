using CampingAssignmentBackendV2.Data;
using LiteDB;

namespace CampingAssignmentBackendV2.Data
{
    public class AnonymousCampingDatabase : IAnonymousCampingDataContext
    {
        // Import LiteDB
        private LiteDatabase _db;

        // Constructor
        public AnonymousCampingDatabase()
        {
            _db = new LiteDatabase(@"data.db");
        }

        // User Methods --------------------------------------------------------------------------------------------------------------------------
        // Add a user
        public void AddUser(User user)
        {
            _db.GetCollection<User>("Users").Insert(user);
        }

        // Get all users
        public IEnumerable<User> GetUsers()
        {
            return _db.GetCollection<User>("Users").FindAll();
        }

        // Get a user by their id
        public User GetUserById(int id)
        {
            return _db.GetCollection<User>("Users").FindById(id);
        }

        // Update a user
        public void UpdateUser(int id, string username, string password, string email)
        {
            var collection = _db.GetCollection<User>("Users");
            var user = collection.FindById(id);
            if (user != null)
            {
                user.Username = username;
                user.Password = password;
                user.Email = email;
                collection.Update(user);
            }
        }

        // Delete a user
        public void DeleteUser(int userId)
        {
            _db.GetCollection<User>("Users").Delete(userId);
        }

        // Camping Spot Methods --------------------------------------------------------------------------------------------------------------------------
        // Add a camping spot
        public void AddCampingSpot(CampingSpot campingSpot)
        {
            _db.GetCollection<CampingSpot>("CampingSpots").Insert(campingSpot);
        }

        // Get all campingspots
        public IEnumerable<CampingSpot> GetCampingSpots()
        {
            return _db.GetCollection<CampingSpot>("CampingSpots").FindAll();
        }

        // Get a camping spot by their id
        public CampingSpot GetCampingSpotById(int id)
        {
            return _db.GetCollection<CampingSpot>("CampingSpots").FindById(id);
        }

        // Get all campingspots of a specific campinground
        public IEnumerable<CampingSpot> GetCampingSpotsByCampingGroundId(int campingGroundId)
        {
            return _db.GetCollection<CampingSpot>("CampingSpots").Find(s => s.CampingGroundId == campingGroundId);
        }

        // Update a campingspot
        public void UpdateCampingSpot(int id, string spotName, int size, string description, decimal price, bool isAvailable, int userId, int campingGroundId, List<int> amenities, List<int> campTypes)
        {
            var collection = _db.GetCollection<CampingSpot>("CampingSpots");
            var campingSpot = collection.FindById(id);
            if (campingSpot != null)
            {
                campingSpot.SpotName = spotName;
                campingSpot.Size = size;
                campingSpot.Description = description;
                campingSpot.Price = price;
                campingSpot.IsAvailable = isAvailable;
                campingSpot.UserId = userId;
                campingSpot.CampingGroundId = campingGroundId;
                campingSpot.Amenities = amenities;
                campingSpot.CampTypes = campTypes;
                collection.Update(campingSpot);
            }
        }

        // Delete a campingspot
        public void DeleteCampingSpot(int id)
        {
            _db.GetCollection<CampingSpot>("CampingSpots").Delete(id);
        }

        // Camping Ground Methods --------------------------------------------------------------------------------------------------------------------------
        // Add a campingground
        public void AddCampingGround(CampingGround campingGround)
        {
            _db.GetCollection<CampingGround>("CampingGrounds").Insert(campingGround);
        }

        // Get all campinggrounds
        public IEnumerable<CampingGround> GetCampingGrounds()
        {
            return _db.GetCollection<CampingGround>("CampingGrounds").FindAll();
        }

        // Get a campingground by it's id
        public CampingGround GetCampingGroundById(int id)
        {
            return _db.GetCollection<CampingGround>("CampingGrounds").FindById(id);
        }

        // Update a campingground
        public void UpdateCampingGround(int id, string name, int amountOfCampingSpots, string location, bool isPetFriendly)
        {
            var collection = _db.GetCollection<CampingGround>("CampingGrounds");
            var campingGround = collection.FindById(id);
            if (campingGround != null)
            {
                campingGround.Name = name;
                campingGround.AmountOfCampingSpots = amountOfCampingSpots;
                campingGround.Location = location;
                campingGround.IsPetFriendly = isPetFriendly;
                collection.Update(campingGround);
            }
        }

        // Delete a campingground
        public void DeleteCampingGround(int id)
        {
            _db.GetCollection<CampingGround>("CampingGrounds").Delete(id);
        }

        // Booking Methods --------------------------------------------------------------------------------------------------------------------------
        // Add a booking
        public void AddBooking(Booking booking)
        {
            _db.GetCollection<Booking>("Bookings").Insert(booking);
        }

        // Get all bookings
        public IEnumerable<Booking> GetBookings()
        {
            return _db.GetCollection<Booking>("Bookings").FindAll();
        }

        // Get a booking by it's id
        public Booking GetBookingById(int id)
        {
            return _db.GetCollection<Booking>("Bookings").FindById(id);
        }

        // Get all bookings tied to a specific user
        public IEnumerable<Booking> GetBookingsByUserId(int userId)
        {
            return _db.GetCollection<Booking>("Bookings").Find(b => b.UserId == userId);
        }

        // Update a booking
        public void UpdateBooking(int id, int userId, int spotId, DateTime startDate, DateTime endDate, decimal totalPrice)
        {
            var collection = _db.GetCollection<Booking>("Bookings");
            var booking = collection.FindById(id);
            if (booking != null)
            {
                booking.UserId = userId;
                booking.SpotId = spotId;
                booking.StartDate = startDate;
                booking.EndDate = endDate;
                booking.TotalPrice = totalPrice;
                collection.Update(booking);
            }
        }

        // Delete a booking
        public void DeleteBooking(int id)
        {
            _db.GetCollection<Booking>("Bookings").Delete(id);
        }

        // CampType Methods --------------------------------------------------------------------------------------------------------------------------
        // Add a camptype
        public void AddCamptype(Camptype camptype)
        {
            _db.GetCollection<Camptype>("Camptypes").Insert(camptype);
        }

        // Get all camptypes
        public IEnumerable<Camptype> GetCamptypes()
        {
            return _db.GetCollection<Camptype>("Camptypes").FindAll();
        }

        // Get a camptype by it's id
        public Camptype GetCamptypeById(int id)
        {
            return _db.GetCollection<Camptype>("Camptypes").FindById(id);
        }

        // Update a camptype
        public void UpdateCamptype(int id, string typeName)
        {
            var collection = _db.GetCollection<Camptype>("Camptypes");
            var camptype = collection.FindById(id);
            if (camptype != null)
            {
                camptype.TypeName = typeName;
                collection.Update(camptype);
            }
        }

        // Delete a camptype
        public void DeleteCamptype(int id)
        {
            _db.GetCollection<Camptype>("Camptypes").Delete(id);
        }

        // Amenity Methods --------------------------------------------------------------------------------------------------------------------------
        // Add an amenity
        public void AddAmenity(Amenity amenity)
        {
            _db.GetCollection<Amenity>("Amenities").Insert(amenity);
        }

        // Get all amenities
        public IEnumerable<Amenity> GetAmenities()
        {
            return _db.GetCollection<Amenity>("Amenities").FindAll();
        }

        // Get an amenity by it's id
        public Amenity GetAmenityById(int id)
        {
            return _db.GetCollection<Amenity>("Amenities").FindById(id);
        }

        // Update an amenity
        public void UpdateAmenity(int id, string name)
        {
            var collection = _db.GetCollection<Amenity>("Amenities");
            var amenity = collection.FindById(id);
            if (amenity != null)
            {
                amenity.Name = name;
                collection.Update(amenity);
            }
        }

        // Delete an amenity
        public void DeleteAmenity(int id)
        {
            _db.GetCollection<Amenity>("Amenities").Delete(id);
        }

        // Comment Methods --------------------------------------------------------------------------------------------------------------------------
        // Add a comment
        public void AddComment(Comment comment)
        {
            _db.GetCollection<Comment>("Comments").Insert(comment);
        }

        // Get all comments
        public IEnumerable<Comment> GetComments()
        {
            return _db.GetCollection<Comment>("Comments").FindAll();
        }

        // Get a comment by it's id
        public Comment GetCommentById(int id)
        {
            return _db.GetCollection<Comment>("Comments").FindById(id);
        }

        // Get all comments tied to a specific user
        public IEnumerable<Comment> GetCommentsByUserId(int userId)
        {
            return _db.GetCollection<Comment>("Comments").Find(c => c.UserId == userId);
        }

        // Update a comment
        public void UpdateComment(int id, int campingSpotId, int userId, string text)
        {
            var collection = _db.GetCollection<Comment>("Comments");
            var comment = collection.FindById(id);
            if (comment != null)
            {
                comment.CampingSpotId = campingSpotId;
                comment.UserId = userId;
                comment.Text = text;
                collection.Update(comment);
            }
        }

        // Delete a comment
        public void DeleteComment(int id)
        {
            _db.GetCollection<Comment>("Comments").Delete(id);
        }

        // Rating Methods --------------------------------------------------------------------------------------------------------------------------
        // Add a rating
        public void AddRating(Rating rating)
        {
            _db.GetCollection<Rating>("Ratings").Insert(rating);
        }

        // Get all ratings
        public IEnumerable<Rating> GetRatings()
        {
            return _db.GetCollection<Rating>("Ratings").FindAll();
        }

        // Get a rating by it's id
        public Rating GetRatingById(int id)
        {
            return _db.GetCollection<Rating>("Ratings").FindById(id);
        }

        // Get all ratings tied to a specific user
        public IEnumerable<Rating> GetRatingsByUserId(int userId)
        {
            return _db.GetCollection<Rating>("Ratings").Find(r => r.UserId == userId);
        }

        // Update a rating
        public void UpdateRating(int id, int campingSpotId, int userId, int score)
        {
            var collection = _db.GetCollection<Rating>("Ratings");
            var rating = collection.FindById(id);
            if (rating != null)
            {
                rating.CampingSpotId = campingSpotId;
                rating.UserId = userId;
                rating.Score = score;
                collection.Update(rating);
            }
        }

        // Delete a rating
        public void DeleteRating(int id)
        {
            _db.GetCollection<Rating>("Ratings").Delete(id);
        }

    }
}