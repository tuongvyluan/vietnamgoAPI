using BusinessObjects;

namespace DTOs
{
    public class Attraction : Location
    {
        public Attraction()
        {
            RawRanking = 5;
            Reviews = new List<Review>();
            Subtype = new List<Subtype>();
            Subtype.Add(new Subtype());
            Photo = new Photo();
        }
        public Attraction(Location l)
        {
            LocationId = l.LocationId;
            RawRanking = 5;
            Description = l.Description;
            LocationImage = l.LocationImage;
            Ranking = l.Ranking;
            Name = l.Name;
            Rating = l.Rating;
            Address = l.Address;
            LocationImage = l.LocationImage;
            Tours = l.Tours;
            Reviews = new List<Review>();
            Subtype = new List<Subtype>();
            Subtype.Add(new Subtype());
            Photo = new Photo();
        }
        public int Num_reviews { get; set; } = 0;
        public Photo Photo { get; set; }
        public List<Subtype> Subtype { get; set; }
        public void CalculateRating()
        {
            if (Reviews == null || Reviews.Count == 0)
            {
                Rating = 0;
                Num_reviews = 0;
            }
            else
            {
                int total = 0;
                foreach (Review review in Reviews)
                {
                    Num_reviews++;
                    total += review.Rating;
                }
                Rating = total / Num_reviews;
            }
        }
    }
}
