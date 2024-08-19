namespace CampingAssignmentBackendV2.Data
{
    public interface IAnonymousCampingDataContext
    {
        // User methods --------------------------------------------------------------------------------------------------------------------------
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(int id, string username, string password, string email);
        void DeleteUser(int userId);

        // Camping Spot methods --------------------------------------------------------------------------------------------------------------------------
        IEnumerable<CampingSpot> GetCampingSpots();
        CampingSpot GetCampingSpotById(int id);
        IEnumerable<CampingSpot> GetCampingSpotsByCampingGroundId(int campingGroundId);
        void AddCampingSpot(CampingSpot campingSpot);
        void UpdateCampingSpot(int id, string spotName, int size, string description, decimal price, bool isAvailable, int userId, int campingGroundId, List<int> amenities, List<int> campTypes);
        void DeleteCampingSpot(int id);

        // Camping Ground methods --------------------------------------------------------------------------------------------------------------------------
        IEnumerable<CampingGround> GetCampingGrounds();
        CampingGround GetCampingGroundById(int id);
        void AddCampingGround(CampingGround campingGround);
        void UpdateCampingGround(int id, string name, int amountOfCampingSpots, string location, bool isPetFriendly);
        void DeleteCampingGround(int id);

        // Booking methods --------------------------------------------------------------------------------------------------------------------------
        IEnumerable<Booking> GetBookings();
        Booking GetBookingById(int id);
        IEnumerable<Booking> GetBookingsByUserId(int userId);
        void AddBooking(Booking booking);
        void UpdateBooking(int id, int userId, int spotId, DateTime startDate, DateTime endDate, decimal totalPrice);
        void DeleteBooking(int id);

        // CampType methods --------------------------------------------------------------------------------------------------------------------------
        IEnumerable<Camptype> GetCamptypes();
        Camptype GetCamptypeById(int id);
        void AddCamptype(Camptype camptype);
        void UpdateCamptype(int id, string typeName);
        void DeleteCamptype(int id);

        // Amenity methods --------------------------------------------------------------------------------------------------------------------------
        IEnumerable<Amenity> GetAmenities();
        Amenity GetAmenityById(int id);
        void AddAmenity(Amenity amenity);
        void UpdateAmenity(int id, string name);
        void DeleteAmenity(int id);

        // Comment methods --------------------------------------------------------------------------------------------------------------------------
        IEnumerable<Comment> GetComments();
        Comment GetCommentById(int id);
        IEnumerable<Comment> GetCommentsByUserId(int userId);
        void AddComment(Comment comment);
        void UpdateComment(int id, int campingSpotId, int userId, string text);
        void DeleteComment(int id);

        // Rating methods --------------------------------------------------------------------------------------------------------------------------
        IEnumerable<Rating> GetRatings();
        Rating GetRatingById(int id);
        IEnumerable<Rating> GetRatingsByUserId(int userId);
        void AddRating(Rating rating);
        void UpdateRating(int id, int campingSpotId, int userId, int score);
        void DeleteRating(int id);

    }
}