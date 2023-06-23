﻿using BusinessObjects;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace WebApp.Pages
{
    public class TourModel : PageModel
    {

        public TourModel()
        {

        }

        public IList<Tour> Tours { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {
            Tours = TourRepository.GetToursbyTran(id);
        }
    }
}
