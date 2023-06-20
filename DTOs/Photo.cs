namespace DTOs
{
    public class Photo
    {
        public Photo()
        {
            Images = new Images();
        }
        public Photo(Images images)
        {
            Images = images;
        }

        public Images Images { get; set; }
    }
}
