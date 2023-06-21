using BusinessObjects;

namespace DTOs
{
    public class Images
    {
        public Images()
        {
            Small = new ImageDTO();
            Medium = new ImageDTO();
            Large = new ImageDTO();
            Thumbnail = new ImageDTO();
            Original = new ImageDTO();
        }
        public ImageDTO Small { get; set; }
        public ImageDTO Medium { get; set; }
        public ImageDTO Large { get; set; }
        public ImageDTO Thumbnail { get; set; }
        public ImageDTO Original { get; set; }
        public static Images ToImages(LocationImage locationImage)
        {
            if (locationImage == null)
            {
                return null;
            }
            Images res = new Images();
            res.Small = locationImage.Small != null ? ImageDTO.ToDTO(locationImage.Small) : new ImageDTO();
            res.Medium = locationImage.Medium != null ? ImageDTO.ToDTO(locationImage.Medium) : new ImageDTO();
            res.Large = locationImage.Large != null ? ImageDTO.ToDTO(locationImage.Large) : new ImageDTO();
            res.Thumbnail = locationImage.Thumbnail != null ? ImageDTO.ToDTO(locationImage.Thumbnail) : new ImageDTO();
            res.Original = locationImage.Original != null ? ImageDTO.ToDTO(locationImage.Original) : new ImageDTO();
            return res;

        }
    }
}
