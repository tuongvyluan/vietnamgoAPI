using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories;
namespace WebApp.Pages
{
    public class AddTourModel : PageModel
    {
        TourRepository _tourRepository;
        LocationRepository _locationRepository;

        public AddTourModel()
        {
            _locationRepository = new LocationRepository();
        }

        public IActionResult OnGet()
        {
            var locations = new List<Location>();
            locations = LocationRepository.GetLoacationListByTran();
            ViewData["LocationId"] = new SelectList(locations, "LocationId", "Name");
            return Page();
        }

        [BindProperty]
        public Tour Tour { get; set; } = default!;
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {


            TourRepository.SaveTour(Tour);
            return RedirectToPage("./Index");
        }
    }
}
