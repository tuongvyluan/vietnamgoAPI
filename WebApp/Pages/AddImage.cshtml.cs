using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;


namespace WebApp.Pages
{
    public class AddImageModel : PageModel
    {
        public Image displayImgLarge { get; set; } = default!;
        public Image displayImgSmall { get; set; } = default!;

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("ImageIdLarge") != null && HttpContext.Session.GetInt32("ImageIdSmall") != null)
            {

                var ImageSmallId = (int)HttpContext.Session.GetInt32("ImageIdSmall");
                var ImageLargeId = (int)HttpContext.Session.GetInt32("ImageIdLarge");

                displayImgSmall = ImageRepository.GetImage(ImageSmallId);
                displayImgLarge = ImageRepository.GetImage(ImageLargeId);

            }
            return Page();
        }
        [BindProperty]
        public Image imgLarge { get; set; } = default!;
        [BindProperty]
        public Image imgSmall { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            LocationImage locationImg = new LocationImage();
            if (!ModelState.IsValid || imgLarge == null || imgSmall == null)
            {
                return Page();
            }
            else
            {

                ImageRepository.SaveImage(imgLarge);
                ImageRepository.SaveImage(imgSmall);

                HttpContext.Session.SetInt32("ImageIdLarge", imgLarge.Id);
                HttpContext.Session.SetInt32("ImageIdSmall", imgSmall.Id);

            }
            return RedirectToPage("./AddImage");
        }
    }
}
