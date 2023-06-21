using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class LocationImageRepository
    {
        public static void SaveLocationImage(LocationImage LocationImage)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    _context.LocationImages.Add(LocationImage);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public static void UpdateLocationImage(LocationImage LocationImage)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    _context.Entry<LocationImage>(LocationImage).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static LocationImage GetLocationImageByLocationId(int locationId)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    LocationImage res = new LocationImage();
                    var l = _context.LocationImages
                        .Include(d => d.Large)
                        .Include(d => d.Small)
                        .Include(d => d.Medium)
                        .Include(d => d.Original)
                        .Include(d => d.Thumbnail)
                        .FirstOrDefault(p => p.LocationId == locationId);
                    if (l == null)
                    {
                        return res;
                    }
                    return l;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
