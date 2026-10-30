using MoviesAPI.Models;
using MoviesAPI.Repositories;

namespace MoviesAPI.Services
{
    public class MovieService(IMovieRepository movieRepository)
    {
        private readonly IMovieRepository _movieRepository = movieRepository;

        public Result AddMovie(Movie movie) => _movieRepository.AddMovie(movie);
        public Result DeleteMovie(int movieId) => _movieRepository.DeleteMovie(movieId);
        public Result UpdateMovie(Movie movie) => _movieRepository.UpdateMovie(movie);

        public List<Movie> GetMovies() => _movieRepository.GetMovies();
        public List<Movie> SearchMovies(string key) => _movieRepository.FindMovies(key);
        public Movie GetOneMovie(int id) => _movieRepository.GetOneMovie(id);
    }
}
