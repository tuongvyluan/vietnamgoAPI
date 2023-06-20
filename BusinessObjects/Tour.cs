using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Tour
{
    public int Id { get; set; }

    public int? TourGuideId { get; set; }

    public int LocationId { get; set; }

    public string? Name { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Location Location { get; set; } = null!;

    public virtual TourGuide? TourGuide { get; set; }
}
