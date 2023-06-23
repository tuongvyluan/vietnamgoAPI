﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;

namespace WebApp.Pages
{
    public class LocationModel : PageModel
    {
        private readonly BusinessObjects.VietnamgoContext _context;

        public LocationModel(BusinessObjects.VietnamgoContext context)
        {
            _context = context;
        }

        public IList<Location> Location { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Locations != null)
            {
                Location = await _context.Locations.ToListAsync();
            }
        }
    }
}
