using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int? LocationId { get; set; }
        public string? Title { get; set; }
        public int Rating { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? PublishedPlatform { get; set; }
        public bool? MachineTranslated { get; set; }
        public string? Summary { get; set; }
        public string? Author { get; set; }

        public virtual Location? Location { get; set; }
    }
}
