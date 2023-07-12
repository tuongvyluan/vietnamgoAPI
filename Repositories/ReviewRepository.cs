using BusinessObjects;
using DTOs;

namespace Repositories
{
	public class ReviewRepository
	{
		public static void SaveReview(Review review)
		{
			try
			{
				using (var _context = new VietnamgoContext())
				{
					_context.Reviews.Add(review);
					_context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex.InnerException);
			}
		}
		public static List<Review> GetReviewsByAttraction(int locationId)
		{
			List<Review> Review = new List<Review>();
			try
			{
				using (var _context = new VietnamgoContext())
				{
					var reviews = _context.Reviews.Where(r => r.LocationId == locationId).ToList();
					if (reviews != null)
					{
						Review = reviews;
					}
					return Review;
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public static void CalculateReview(out int total, out double review, int locationId)
		{
			try
			{
				using (var _context = new VietnamgoContext())
				{
					var reviews = _context.Reviews.Where(r => r.LocationId == locationId).ToList();
					if (reviews != null)
					{
						Attraction a = new Attraction();
						a.Reviews = reviews;
						a.CalculateRating();
						total = a.Num_reviews;
						review = a.Rating;
					}
					else
					{
						total = 0;
						review = 0;
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
