using DTOs;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace VietnamgoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttractionController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAttractions()
        {
            AttractionResponse response = new AttractionResponse();
            List<Attraction> attractions = LocationRepository.GetAttractions();
            foreach (Attraction attraction in attractions)
            {
                attraction.Photo.Images = Images.ToImages(LocationImageRepository.GetLocationImageByLocationId(attraction.LocationId));
            }
            response.Data = attractions;
            response.CalculatePaging();
            return Ok(response);
        }
        [HttpGet("id:int")]
        public ActionResult GetAttraction(int id)
        {
            Attraction attraction = LocationRepository.GetLocation(id);
            if (attraction == null)
            {
                return NotFound();
            }
            attraction.Photo.Images = Images.ToImages(LocationImageRepository.GetLocationImageByLocationId(attraction.LocationId));
            return Ok(attraction);
        }
    }
}
