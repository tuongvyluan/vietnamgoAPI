using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class TourGuide
    {
        public TourGuide()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
