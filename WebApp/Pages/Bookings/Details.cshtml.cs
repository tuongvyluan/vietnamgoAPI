using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace WebApp.Pages.Bookings
{
    public class DetailsModel : PageModel
    {

        public DetailsModel()
        {
        }

        public Booking Booking { get; set; } = default!;

        public IActionResult OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = BookingRepository.GetBooking(id);
            if (booking.Customer == null)
            {
                return NotFound();
            }
            else
            {
                Booking = booking;
            }
            return Page();
        }
    }
}
