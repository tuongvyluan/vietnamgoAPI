using BusinessObjects;

namespace DTOs
{
    public class Images
    {
        public Images()
        {
            Small = new Image();
            Medium = new Image();
            Large = new Image();
            Thumbnail = new Image();
            Original = new Image();
        }
        public Image Small { get; set; }
        public Image Medium { get; set; }
        public Image Large { get; set; }
        public Image Thumbnail { get; set; }
        public Image Original { get; set; }
    }
}
