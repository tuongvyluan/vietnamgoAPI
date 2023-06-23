using BusinessObjects;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace WebApp.Pages
{
    public class Index1Model : PageModel
    {
        public IList<Location> Location { get; set; } = default!;
        public Image img { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Location = LocationRepository.GetLoacationListByTran();
        }
    }
}
