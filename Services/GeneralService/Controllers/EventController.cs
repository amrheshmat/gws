using Microsoft.AspNetCore.Mvc;
using MWS.Data.Entities;
using MWS.Data.ViewModels;
using MWS.Infrustructure.Repositories;

namespace GeneralService.Controllers
{
    public class BookingSlot
    {
        public string Day { get; set; }
        public int Hour { get; set; }
        public bool IsAvailable { get; set; }
    }
    public class EventController : Controller
    {
        private IRepository _context;

        public EventController(IRepositoryFactory context)
        {
            _context = context.Create("AGGRDB");
        }

        private static List<BookingSlot> AvailableSlots = new List<BookingSlot>
    {
        new BookingSlot { Day = "Monday", Hour = 9, IsAvailable = true },
        new BookingSlot { Day = "Monday", Hour = 10, IsAvailable = true },
        new BookingSlot { Day = "Monday", Hour = 11, IsAvailable = false }, // example of an unavailable hour
        new BookingSlot { Day = "Tuesday", Hour = 14, IsAvailable = true },
        new BookingSlot { Day = "Wednesday", Hour = 9, IsAvailable = true },
        new BookingSlot { Day = "Friday", Hour = 13, IsAvailable = true }
    };
        // Action to display the calendar view
        public IActionResult Index()
        {
            return View();
        }

        // Action to get sessions for a specific day
        public IActionResult GetSessionsForDay(DateTime day)
        {
            var sessions = _context.Filter<MWS.Data.Entities.Session>(s => s.IsAvailable != 'N')  // Get sessions for the specific day
                .Select(s => new
                {
                    id = s.Id,
                    title = s.Title,
                    start = s.StartDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                    end = s.EndDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                    description = s.Description,
                    location = s.Location
                })
                .ToList();

            return Json(sessions);
        }
        [HttpPost]
        public JsonResult BookSlot(string datetime)
        {
            var n = DateTime.UtcNow;
            // Book the selected slot
            //var session = _context.Filter<MWS.Data.Entities.Session>().FirstOrDefault();
            //if (session != null && session.IsAvailable != 'N' && session.IsBooked != 'Y')
            //{
            //    session.IsBooked = 'Y';
            //    session.IsAvailable = 'N'; // Mark it as unavailable after booking
            //    _context.SaveChanges();
            //    return Json(new { success = true });
            //}
            return Json(new { success = false, message = "Session already booked or not available." });
        }

    }


}
