using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Contracts
{
    public class CreateMovieRequest
    {
        [Required]
        [StringLength(100, ErrorMessage ="The title is either too short or too long",MinimumLength =2)]
        public string Title { get; set; }

        [Required]
        [StringLength(400, ErrorMessage = "The description is either too short or too long", MinimumLength = 20)]
        public string Description { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The genre is either too short or too long", MinimumLength = 3)]
        public string Genre { get; set; }
    }
}
