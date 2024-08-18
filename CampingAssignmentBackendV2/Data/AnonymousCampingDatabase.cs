using CampingAssignmentBackendV2.Data;
using LiteDB;

namespace CampingAssignmentBackendV2.Data
{
    public class AnonymousCampingDatabase : IAnonymousCampingDataContext
    {
        private LiteDatabase _db;

        public AnonymousCampingDatabase()
        {
            _db = new LiteDatabase(@"data.db");
        }

        // User Methods --------------------------------------------------------------------------------------------------------------------------
        public void AddUser(User user)
        {
            _db.GetCollection<User>("Users").Insert(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _db.GetCollection<User>("Users").FindAll();
        }

        public User GetUserById(int id)
        {
            return _db.GetCollection<User>("Users").FindById(id);
        }

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

        public void DeleteUser(int userId)
        {
            _db.GetCollection<User>("Users").Delete(userId);
        }

        // Camping Spot Methods --------------------------------------------------------------------------------------------------------------------------
        public void AddCampingSpot(CampingSpot campingSpot)
        {
            _db.GetCollection<CampingSpot>("CampingSpots").Insert(campingSpot);
        }

        public IEnumerable<CampingSpot> GetCampingSpots()
        {
            return _db.GetCollection<CampingSpot>("CampingSpots").FindAll();
        }

        public CampingSpot GetCampingSpotById(int id)
        {
            return _db.GetCollection<CampingSpot>("CampingSpots").FindById(id);
        }

        public IEnumerable<CampingSpot> GetCampingSpotsByCampingGroundId(int campingGroundId)
        {
            return _db.GetCollection<CampingSpot>("CampingSpots").Find(s => s.CampingGroundId == campingGroundId);
        }

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

        public void DeleteCampingSpot(int id)
        {
            _db.GetCollection<CampingSpot>("CampingSpots").Delete(id);
        }

        // Camping Ground Methods --------------------------------------------------------------------------------------------------------------------------
        public void AddCampingGround(CampingGround campingGround)
        {
            _db.GetCollection<CampingGround>("CampingGrounds").Insert(campingGround);
        }

        public IEnumerable<CampingGround> GetCampingGrounds()
        {
            return _db.GetCollection<CampingGround>("CampingGrounds").FindAll();
        }

        public CampingGround GetCampingGroundById(int id)
        {
            return _db.GetCollection<CampingGround>("CampingGrounds").FindById(id);
        }

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

        public void DeleteCampingGround(int id)
        {
            _db.GetCollection<CampingGround>("CampingGrounds").Delete(id);
        }

        // Booking Methods --------------------------------------------------------------------------------------------------------------------------
        public void AddBooking(Booking booking)
        {
            _db.GetCollection<Booking>("Bookings").Insert(booking);
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _db.GetCollection<Booking>("Bookings").FindAll();
        }

        public Booking GetBookingById(int id)
        {
            return _db.GetCollection<Booking>("Bookings").FindById(id);
        }

        public IEnumerable<Booking> GetBookingsByUserId(int userId)
        {
            return _db.GetCollection<Booking>("Bookings").Find(b => b.UserId == userId);
        }

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

        public void DeleteBooking(int id)
        {
            _db.GetCollection<Booking>("Bookings").Delete(id);
        }

        // CampType Methods --------------------------------------------------------------------------------------------------------------------------
        public void AddCamptype(Camptype camptype)
        {
            _db.GetCollection<Camptype>("Camptypes").Insert(camptype);
        }

        public IEnumerable<Camptype> GetCamptypes()
        {
            return _db.GetCollection<Camptype>("Camptypes").FindAll();
        }

        public Camptype GetCamptypeById(int id)
        {
            return _db.GetCollection<Camptype>("Camptypes").FindById(id);
        }

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

        public void DeleteCamptype(int id)
        {
            _db.GetCollection<Camptype>("Camptypes").Delete(id);
        }

        // Amenity Methods --------------------------------------------------------------------------------------------------------------------------
        public void AddAmenity(Amenity amenity)
        {
            _db.GetCollection<Amenity>("Amenities").Insert(amenity);
        }

        public IEnumerable<Amenity> GetAmenities()
        {
            return _db.GetCollection<Amenity>("Amenities").FindAll();
        }

        public Amenity GetAmenityById(int id)
        {
            return _db.GetCollection<Amenity>("Amenities").FindById(id);
        }

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

        public void DeleteAmenity(int id)
        {
            _db.GetCollection<Amenity>("Amenities").Delete(id);
        }

        // Comment Methods --------------------------------------------------------------------------------------------------------------------------
        public void AddComment(Comment comment)
        {
            _db.GetCollection<Comment>("Comments").Insert(comment);
        }

        public IEnumerable<Comment> GetComments()
        {
            return _db.GetCollection<Comment>("Comments").FindAll();
        }

        public Comment GetCommentById(int id)
        {
            return _db.GetCollection<Comment>("Comments").FindById(id);
        }

        public IEnumerable<Comment> GetCommentsByUserId(int userId)
        {
            return _db.GetCollection<Comment>("Comments").Find(c => c.UserId == userId);
        }

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

        public void DeleteComment(int id)
        {
            _db.GetCollection<Comment>("Comments").Delete(id);
        }

        // Rating Methods --------------------------------------------------------------------------------------------------------------------------
        public void AddRating(Rating rating)
        {
            _db.GetCollection<Rating>("Ratings").Insert(rating);
        }

        public IEnumerable<Rating> GetRatings()
        {
            return _db.GetCollection<Rating>("Ratings").FindAll();
        }

        public Rating GetRatingById(int id)
        {
            return _db.GetCollection<Rating>("Ratings").FindById(id);
        }

        public IEnumerable<Rating> GetRatingsByUserId(int userId)
        {
            return _db.GetCollection<Rating>("Ratings").Find(r => r.UserId == userId);
        }

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

        public void DeleteRating(int id)
        {
            _db.GetCollection<Rating>("Ratings").Delete(id);
        }

    }
}