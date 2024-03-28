namespace HotelAppLibrary.Models
{
    public class BookingsFullModel
    {
        public int ID { get; set; }
        public int RoomID { get; set; }
        public int GuestID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}
        public bool CheckedIn { get; set; }
        public decimal TotalCost { get; set; }
        public string FirstName { get; set; }
        public string LastName { get;}
        public string RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomTypeTitle { get; set;}
        public string RoomTypeDescription { get; set;}
        public decimal Price { get; set;}
    }
}
