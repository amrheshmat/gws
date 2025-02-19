using Microsoft.AspNetCore.Mvc;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;

namespace GeneralService.Controllers
{
    public class EventController : Controller
    {
        private IRepository _context;

        public EventController(IRepositoryFactory context)
        {
            _context = context.Create("AGGRDB");
        }
        // Action to display the calendar view
        public IActionResult Index()
        {
            return View();
        }

        // Action to get sessions for a specific day
        public IActionResult GetSessionsForDay(DateTime day)
        {
            var sessions = _context.Filter<Session>(s => s.StartDate.Date == day.Date && s.IsAvailable != 'N')  // Get sessions for the specific day
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

        // Action to book a session at a specific time
        [HttpPost]
        public IActionResult BookSession(int sessionId)
        {
            var session = _context.Filter<Session>(s => s.Id == sessionId).FirstOrDefault();
            if (session != null && session.IsAvailable != 'N' && session.IsBooked != 'Y')
            {
                session.IsBooked = 'Y';
                session.IsAvailable = 'N'; // Mark it as unavailable after booking
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Session already booked or not available." });
        }
    }


}
