using BusinessObjects;
using DTOs;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class LocationRepository
    {
        public static void SaveLocation(Location Location)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    _context.Locations.Add(Location);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public static void UpdateLocation(Location Location)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    _context.Entry<Location>(Location).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Attraction GetLocation(int id)
        {
            Location Location = new Location();
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var f = _context.Locations.FirstOrDefault(p => p.LocationId == id);
                    if (f != null)
                    {
                        f.Tours = _context.Tours.Where(p => p.LocationId == id).ToList();
                        Location = f;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return new Attraction(Location);
        }
        public static List<Attraction> GetAttractions()
        {
            Location Location = new Location();
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var locations = _context.Locations.ToList();
                    if (locations == null)
                    {
                        locations = new List<Location>();
                    }
                    List<Attraction> result = new List<Attraction>();
                    foreach (Location l in locations)
                    {
                        result.Add(new Attraction(l));
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<Location> GetLoacationListByTran()
        {
            Location Location = new Location();
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var locations = _context.Locations.Include(P => P.LocationImage.Thumbnail).ToList();
                    if (locations == null)
                    {
                        locations = new List<Location>();
                    }
                    return locations;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Location GetLocationbyTran(int id)
        {
            Location Location = new Location();
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var f = _context.Locations.FirstOrDefault(p => p.LocationId == id);
                    Location = f;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Location;
        }
    }
}
