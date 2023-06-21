using BusinessObjects;

namespace DTOs
{
    public class ImageDTO
    {
        public int Id { get; set; }

        public double? Width { get; set; }

        public double? Height { get; set; }

        public string? Url { get; set; }
        public static ImageDTO ToDTO(Image image)
        {
            ImageDTO dto = new ImageDTO();
            dto.Id = image.Id;
            dto.Width = image.Width;
            dto.Height = image.Height;
            dto.Url = image.Url;
            return dto;
        }
    }
}
