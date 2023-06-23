using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class BookingRepository
    {
        public static void SaveBooking(Booking Booking)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    _context.Bookings.Add(Booking);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public static void UpdateBooking(Booking Booking)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    _context.Entry<Booking>(Booking).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Booking GetBooking(string id)
        {
            Booking Booking = new Booking();
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var f = _context.Bookings.Include(b => b.Tour).Include(b => b.Customer).SingleOrDefault(p => p.Id.Equals(id));
                    if (f != null)
                    {
                        Booking = f;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Booking;
        }
        public static List<Booking> GetBookings()
        {
            List<Booking> bookings = new List<Booking>();
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var f = _context.Bookings.Include(b => b.Tour).Include(b => b.Customer).ToList();
                    if (f != null)
                    {
                        bookings = f;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bookings;
        }
        public static List<Booking> GetBookingsByCustomer(int customerId)
        {
            List<Booking> bookings = new List<Booking>();
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var f = _context.Bookings.Include(b => b.Tour.Location.LocationImage.Small).Where(b => b.CustomerId == customerId).OrderByDescending(b => b.BookingDate).ToList();
                    if (f != null)
                    {
                        bookings = f;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bookings;
        }
    }
}
