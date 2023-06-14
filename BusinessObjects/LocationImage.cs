using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class LocationImage
{
    public int LocationId { get; set; }

    public int? SmallId { get; set; }

    public int? MediumId { get; set; }

    public int? LargeId { get; set; }

    public int? OriginalId { get; set; }

    public int? ThumbnailId { get; set; }

    public virtual Image? Large { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual Image? Medium { get; set; }

    public virtual Image? Original { get; set; }

    public virtual Image? Small { get; set; }

    public virtual Image? Thumbnail { get; set; }
}
