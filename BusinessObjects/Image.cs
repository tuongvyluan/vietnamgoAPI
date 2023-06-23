using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Image
    {
        public Image()
        {
            LocationImageLarges = new HashSet<LocationImage>();
            LocationImageMedia = new HashSet<LocationImage>();
            LocationImageOriginals = new HashSet<LocationImage>();
            LocationImageSmalls = new HashSet<LocationImage>();
            LocationImageThumbnails = new HashSet<LocationImage>();
        }

        public int Id { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public string? Url { get; set; }

        public virtual ICollection<LocationImage> LocationImageLarges { get; set; }
        public virtual ICollection<LocationImage> LocationImageMedia { get; set; }
        public virtual ICollection<LocationImage> LocationImageOriginals { get; set; }
        public virtual ICollection<LocationImage> LocationImageSmalls { get; set; }
        public virtual ICollection<LocationImage> LocationImageThumbnails { get; set; }
    }
}
