using HotelAppLibrary.Database;
using HotelAppLibrary.Models;

namespace HotelAppLibrary.Data
{
    public class SqlData : IDatabaseData
    {
        private readonly ISqlDataAcess _db;
        public SqlData(ISqlDataAcess db)
        {
            _db = db;
        }
        private const string connectionstringName = "SqlDb";
        public List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {
            return _db.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypes_GetAvailableTypes", new { startDate, endDate }, connectionstringName, true);
        }
        public void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeID)
        {
            GuestModel guest = _db.LoadData<GuestModel, dynamic>("dbo.spGuests_Insert", new { firstName, lastName }, connectionstringName, true).First();
            RoomTypeModel roomType = _db.LoadData<RoomTypeModel, dynamic>("select * from dbo.RoomTypes where ID = @ID", new { ID = roomTypeID }, connectionstringName, false).First();
            TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);
            List<RoomModel> availableRooms = _db.LoadData<RoomModel, dynamic>("dbo.spRoom_GetAvailableRooms", new { startDate, endDate, roomTypeID }, connectionstringName, true);
            _db.SaveData("dbo.spBookings_Insert", new { roomID = availableRooms.First().ID, guestID = guest.ID, startDate, endDate, totalCost = timeStaying.Days * roomType.Price }, connectionstringName, true);
        }
        public List<BookingsFullModel> SearchBookings(string lastName)
        {
            return _db.LoadData<BookingsFullModel, dynamic>("dbo.spBooking_Search", new { lastName, startDate = DateTime.Now.Date }, connectionstringName, true);
        }
        public void CheckInGuest(int bookingID)
        {
            _db.SaveData("dbo.spBookings_CheckIn", new { bookingID }, connectionstringName, true);
        }
        public RoomTypeModel GetRoomTypeByID(int ID)
        {
            return _db.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypes_GetByID", new { ID }, connectionstringName, true).FirstOrDefault();
        }
    }
}