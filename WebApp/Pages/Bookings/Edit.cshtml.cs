using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories;

namespace WebApp.Pages.Bookings
{
    public class EditModel : PageModel
    {

        public EditModel()
        {
        }
        [BindProperty]
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
                if (!Booking.PaymentStatus)
                {
                    Booking.PaymentDate = DateTime.Now;
                }
                List<Customer> customers = new List<Customer> { booking.Customer };
                ViewData["CustomerId"] = new SelectList(customers, "Id", "Email");
                List<Tour> tours = new List<Tour> { booking.Tour };
                ViewData["TourId"] = new SelectList(tours, "Id", "TourName");
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (BookingExists(Booking.Id))
            {
                if (!Booking.PaymentStatus)
                {
                    Booking.PaymentDate = null;
                }
                BookingRepository.UpdateBooking(Booking);
            }

            return RedirectToPage("./Index");
        }

        private bool BookingExists(string id)
        {
            return (BookingRepository.GetBooking(id).Id != null);
        }
    }
}
