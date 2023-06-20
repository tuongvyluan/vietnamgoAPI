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
        public static Booking GetBooking(int id)
        {
            Booking Booking = new Booking();
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var f = _context.Bookings.SingleOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Booking;
        }
    }
}
