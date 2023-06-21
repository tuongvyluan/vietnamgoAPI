using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Booking
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? TourId { get; set; }

    public int? TouristNum { get; set; }

    public double? Discount { get; set; }

    public bool PaymentStatus { get; set; }

    public bool? TripStatus { get; set; }

    public DateTime? BookingDate { get; set; }

    public DateTime? TripDate { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Tour? Tour { get; set; }
}
