using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Tour
    {
        public Tour()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public int? TourGuideId { get; set; }
        public int LocationId { get; set; }
        public string? TourName { get; set; }
        public string? TourDescription { get; set; }
        public string? TourTime { get; set; }
        public decimal Price { get; set; }

        public virtual Location Location { get; set; } = null!;
        public virtual TourGuide? TourGuide { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
