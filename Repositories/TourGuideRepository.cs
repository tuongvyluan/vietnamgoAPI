using BusinessObjects;

namespace Repositories
{
    public class TourGuideRepository
    {
        public static TourGuide? Login(TourGuide account)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var user = _context.TourGuides.FirstOrDefault(u => u.Email.Equals(account.Email) && u.Password.Equals(account.Password));
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool CheckExistEmail(string email)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var user = _context.TourGuides.FirstOrDefault(u => u.Email.Equals(email));
                    return user != null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Create(TourGuide t)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    _context.TourGuides.Add(t);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static TourGuide? GetTourGuide(int id)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var user = _context.TourGuides.FirstOrDefault(t => t.Id == id);
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static TourGuide? GetTourGuide(string email)
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    var user = _context.TourGuides.FirstOrDefault(t => t.Email.Equals(email));
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<TourGuide> GetList()
        {
            try
            {
                using (var _context = new VietnamgoContext())
                {
                    return _context.TourGuides.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
