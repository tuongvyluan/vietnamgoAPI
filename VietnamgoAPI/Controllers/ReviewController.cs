using BusinessObjects;
using DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace VietnamgoAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[EnableCors]
	public class ReviewController : Controller
	{

		[HttpPost]
		public void Post(ReviewDTO reviewDTO)
		{
			Location l = LocationRepository.GetLocation(reviewDTO.LocationId);
			if (l != null)
			{
				Review review = new Review();
				review.Author = reviewDTO.Author;
				review.Summary = reviewDTO.Summary;
				review.Rating = reviewDTO.Rating;
				review.Title = reviewDTO.Title;
				review.LocationId = reviewDTO.LocationId;
				review.PublishedDate = DateTime.Now;
				ReviewRepository.SaveReview(review);

				int total;
				double rating;
				ReviewRepository.CalculateReview(out total, out rating, l.LocationId);
				l.Rating = rating;
				LocationRepository.UpdateLocation(l);
			}
		}
	}
}
