using BusinessObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace VietnamgoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class BookingController : Controller
    {
        [HttpGet("All")]
        public IActionResult GetAllBookings()
        {
            List<Booking> bookings = BookingRepository.GetBookings();
            return Ok(bookings);
        }
        [HttpGet("{customerId:int}")]
        public IActionResult GetBookingsByCustomer(int customerId)
        {
            List<Booking> bookings = BookingRepository.GetBookingsByCustomer(customerId);
            return Ok(bookings);
        }
        [HttpGet]
        public IActionResult GetBooking(string bookingId)
        {
            Booking booking = BookingRepository.GetBooking(bookingId);
            return Ok(booking);
        }
        [HttpPost]
        public IActionResult CreateBooking(int customerId, int touristNum, int tourId)
        {
            Customer customer = CustomerRepository.GetCustomer(customerId);
            if (customer.Id == 0)
            {
                return BadRequest("The customer booking tour does not exist");
            }
            Tour tour = TourRepository.GetTour(tourId);
            if (tour.Id == 0)
            {
                return BadRequest("The tour being booked does not existed");
            }
            if (touristNum <= 0)
            {
                return BadRequest("Number of tourist must be greater than 0");
            }
            string bookingId = "DH" + (new Random().Next(1000000, 9999999)).ToString();
            Booking booking = new Booking();
            booking.Id = bookingId;
            booking.TourId = tourId;
            booking.CustomerId = customerId;
            booking.TouristNum = touristNum;
            booking.BookingDate = DateTime.Now;
            booking.Discount = 0;
            BookingRepository.SaveBooking(booking);
            booking.Tour = tour;
            booking.Customer = customer;
            return Ok(booking);
        }
    }
}
