using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
namespace WebApp.Pages
{
    public class LocationDisplayModel : PageModel
    {

        public LocationDisplayModel()
        {

        }

        public Location Location { get; set; } = default!;
        public Image displayImgLarge { get; set; } = default!;
        public Image displayImgSmall { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            AddLocationImage();
            var LocaionId = (int)HttpContext.Session.GetInt32("LocationComplete");
            var ImageSmallId = (int)HttpContext.Session.GetInt32("ImageIdSmall");
            var ImageLargeId = (int)HttpContext.Session.GetInt32("ImageIdLarge");

            displayImgSmall = ImageRepository.GetImage(ImageSmallId);
            displayImgLarge = ImageRepository.GetImage(ImageLargeId);
            Location = LocationRepository.GetLocationbyTran(LocaionId);
            ClearSection();
            return Page();
        }

        public void AddLocationImage()
        {
            var ImageSmallId = (int)HttpContext.Session.GetInt32("ImageIdSmall");
            var ImageLargeId = (int)HttpContext.Session.GetInt32("ImageIdLarge");
            var LocaionId = (int)HttpContext.Session.GetInt32("LocationComplete");
            LocationImage locationImg = new LocationImage();

            locationImg.SmallId = ImageSmallId;
            locationImg.MediumId = ImageSmallId;
            locationImg.ThumbnailId = ImageSmallId;

            locationImg.LargeId = ImageLargeId;
            locationImg.OriginalId = ImageLargeId;

            locationImg.LocationId = LocaionId;

            LocationImageRepository.SaveLocationImage(locationImg);

        }

        public void ClearSection()
        {
            HttpContext.Session.Remove("ImageIdSmall");
            HttpContext.Session.Remove("ImageIdLarge");
            HttpContext.Session.Remove("LocationComplete");

        }
    }
}
