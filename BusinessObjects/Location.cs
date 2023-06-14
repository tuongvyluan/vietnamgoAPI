using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Location
{
    public int LocationId { get; set; }

    public string? Name { get; set; }

    public int RawRanking { get; set; }

    public double Rating { get; set; }

    public string? Ranking { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public virtual LocationImage? LocationImage { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
