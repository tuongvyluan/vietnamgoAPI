using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories;
namespace WebApp.Pages
{
    public class EditTourModel : PageModel
    {
        TourRepository _tourRepository;
        LocationRepository _locationRepository;

        public EditTourModel()
        {
            _locationRepository = new LocationRepository();
        }

        public IActionResult OnGet(int id)
        {
            var locations = new List<Location>();
            locations = LocationRepository.GetLoacationListByTran();
            ViewData["LocationId"] = new SelectList(locations, "LocationId", "Name");
            Tour = TourRepository.GetTour(id);
            return Page();
        }

        [BindProperty]
        public Tour Tour { get; set; } = default!;
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPost()
        {
            TourRepository.UpdateTour(Tour);
            return RedirectToPage("./Index");
        }
    }
}
