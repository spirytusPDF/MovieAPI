using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Contracts
{
    public class UpdateMovieRequest
    {
        [Required]
        [StringLength(100, ErrorMessage = "The title is either too short or too long", MinimumLength = 2)]
        public string Title { get; set; }
        [Required]
        [StringLength(400, ErrorMessage = "The description is either too short or too long", MinimumLength = 20)]
        public string Description { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The genre is either too short or too long", MinimumLength = 3)]
        public string Genre { get; set; }
        [Required]
        [Range(0.1, 10, ErrorMessage = "The rating must be in the range of 0.1 to 10")]
        public double Rating { get; set; }

        
        [RegularExpression(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)")]
        public string? ImageUrl { get; set; } 
    }
}
