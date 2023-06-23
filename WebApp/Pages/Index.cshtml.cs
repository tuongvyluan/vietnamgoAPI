using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {

        public IndexModel()
        {

        }
        public IList<Location> Location { get; set; } = default!;
        public Image img { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var id = HttpContext.Session.GetInt32("ID");
            if (id == null)
            {
                return RedirectToPage("./Login");
            }
            Location = LocationRepository.GetLoacationListByTran();
            return Page();
        }


    }
}