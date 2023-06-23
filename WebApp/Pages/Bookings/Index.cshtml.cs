using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;

namespace WebApp.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.VietnamgoContext _context;

        public IndexModel(BusinessObjects.VietnamgoContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bookings != null)
            {
                Booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Tour).ToListAsync();
            }
        }
    }
}
