using MoviesAPI.Models;

namespace MoviesAPI.Repositories
{
    public interface IMovieRepository
    {
        public Result AddMovie(Movie movie);
        public Result UpdateMovie(Movie movie);

        public List<Movie> GetMovies();
        public Movie GetOneMovie(int id);

        public Result DeleteMovie(int id);

        public List<Movie> FindMovies(string key);
    }
}
