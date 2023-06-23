﻿using BusinessObjects;
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

        public async Task OnGetAsync()
        {
            Location = LocationRepository.GetLoacationListByTran();

        }



    }
}