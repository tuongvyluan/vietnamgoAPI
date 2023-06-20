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
            LocationImage LocationImage = new LocationImage();
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var f = _context.LocationImages.SingleOrDefault(p => p.LocationId == locationId);
                    f.Large = _context.Images.FirstOrDefault(i => i.Id == f.LargeId);
                    f.Medium = _context.Images.FirstOrDefault(i => i.Id == f.MediumId);
                    f.Small = _context.Images.FirstOrDefault(i => i.Id == f.SmallId);
                    f.Original = _context.Images.FirstOrDefault(i => i.Id == f.OriginalId);
                    f.Thumbnail = _context.Images.FirstOrDefault(i => i.Id == f.ThumbnailId);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return LocationImage;
        }
    }
}
