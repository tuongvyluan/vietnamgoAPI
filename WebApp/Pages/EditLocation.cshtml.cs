using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace WebApp.Pages
{
    public class EditLocationModel : PageModel
    {


        public EditLocationModel()
        {

        }

        public IActionResult OnGet(int id)
        {
            Location = LocationRepository.GetLocation(id);
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

            LocationRepository.UpdateLocation(Location);
            HttpContext.Session.SetInt32("LocationComplete", Location.LocationId);
            return RedirectToPage("./Index");
        }
    }
}
