using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace WebApp.Pages.Bookings
{
    public class IndexModel : PageModel
    {

        public IndexModel()
        {
        }

        public List<Booking> Booking { get; set; } = default!;

        public IActionResult OnGet()
        {
            Booking = BookingRepository.GetBookings();
            return Page();
        }
    }
}
