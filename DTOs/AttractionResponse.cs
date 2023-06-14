namespace DTOs
{
    public class AttractionResponse
    {
        public AttractionResponse()
        {
            Data = new List<Attraction>();
            Paging = new PagingResult();
        }
        public List<Attraction> Data { get; set; }
        public PagingResult Paging { get; set; }
        public void CalculatePaging()
        {
            if (Data == null || Data.Count == 0)
            {
                Paging.Total_results = 0;
                Paging.Results = 0;
            }
            else
            {
                Paging.Total_results = Data.Count;
                Paging.Results = Data.Count;
            }
        }
    }
}
