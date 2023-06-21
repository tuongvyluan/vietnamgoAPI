using System.Runtime.Serialization;

namespace BusinessObjects;

public partial class Image
{
    public int Id { get; set; }

    public double? Width { get; set; }

    public double? Height { get; set; }

    public string? Url { get; set; }
    [IgnoreDataMember]
    public virtual ICollection<LocationImage> LocationImageLarges { get; set; } = new List<LocationImage>();
    [IgnoreDataMember]
    public virtual ICollection<LocationImage> LocationImageMedia { get; set; } = new List<LocationImage>();
    [IgnoreDataMember]
    public virtual ICollection<LocationImage> LocationImageOriginals { get; set; } = new List<LocationImage>();
    [IgnoreDataMember]
    public virtual ICollection<LocationImage> LocationImageSmalls { get; set; } = new List<LocationImage>();
    [IgnoreDataMember]
    public virtual ICollection<LocationImage> LocationImageThumbnails { get; set; } = new List<LocationImage>();
}
