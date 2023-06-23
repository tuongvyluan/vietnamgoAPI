using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace WebApp.Pages
{
    public class AddLocationModel : PageModel
    {


        public AddLocationModel()
        {

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Location Location { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Location == null)
            {
                return Page();
            }

            LocationRepository.SaveLocation(Location);
            HttpContext.Session.SetInt32("LocationComplete", Location.LocationId);
            return RedirectToPage("./AddImage");
        }
    }
}
