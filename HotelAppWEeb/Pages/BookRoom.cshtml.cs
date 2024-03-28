using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelAppWeb.Pages
{
    public class BookRoomModel : PageModel
    {
        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LasteName { get; set; }

        [BindProperty(SupportsGet = true)]
        public int RoomTypeID { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }
        public RoomTypeModel RoomType { get; set; }
        public IDatabaseData _db { get; }
        public BookRoomModel(IDatabaseData db)
        {
            _db = db;
        }
        public void OnGet()
        {
            if (RoomTypeID > 0) 
            {
                RoomType = _db.GetRoomTypeByID(RoomTypeID);
            }
        }

        public IActionResult OnPost()
        {
            _db.BookGuest(FirstName, LasteName, StartDate, EndDate, RoomTypeID);    
            return RedirectToPage("/Index");
        }

    }

}
