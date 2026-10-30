namespace MoviesAPI.Contracts
{
    public class MovieResponse
    {
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string Genre { get; set; } 
        public double Rating { get; set; }

        public string ImageUrl { get; set; } 
    }
}
