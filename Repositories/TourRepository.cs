using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class TourRepository
    {
        public static void SaveTour(Tour Tour)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    _context.Tours.Add(Tour);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public static void UpdateTour(Tour Tour)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    _context.Entry<Tour>(Tour).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Tour GetTour(int id)
        {
            Tour Tour = new Tour();
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var f = _context.Tours.SingleOrDefault(p => p.Id == id);
                    if (f != null)
                    {
                        var location = _context.Locations.SingleOrDefault(l => l.LocationId == f.LocationId);
                        if (location != null)
                        {
                            f.Location = location;
                            Tour = f;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Tour;
        }
        public static List<Tour> GetTours()
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    List<Tour> tours = _context.Tours.ToList();
                    if (tours == null)
                    {
                        tours = new List<Tour>();
                    }
                    foreach (var t in tours)
                    {
                        t.Location = LocationRepository.GetLocation(t.LocationId);
                    }
                    return tours;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<Tour> GetToursbyTran(int locationId)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    List<Tour> tours = _context.Tours.Where(t => t.LocationId == locationId).ToList();
                    if (tours == null)
                    {
                        tours = new List<Tour>();
                    }

                    return tours;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
