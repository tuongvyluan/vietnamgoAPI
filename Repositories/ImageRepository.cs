using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ImageRepository
    {
        public static void SaveImage(Image Image)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    _context.Images.Add(Image);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public static void UpdateImage(Image Image)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    _context.Entry<Image>(Image).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Image GetImage(int id)
        {
            Image Image = new Image();
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var f = _context.Images.SingleOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Image;
        }
    }
}
