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
        public static Images ToImages(LocationImage locationImage)
        {
            Images res = new Images();
            res.Small = locationImage.Small != null ? locationImage.Small : new Image();
            res.Medium = locationImage.Medium != null ? locationImage.Medium : new Image();
            res.Large = locationImage.Large != null ? locationImage.Large : new Image();
            res.Thumbnail = locationImage.Thumbnail != null ? locationImage.Thumbnail : new Image();
            res.Original = locationImage.Original != null ? locationImage.Original : new Image();
            return res;

        }
    }
}
