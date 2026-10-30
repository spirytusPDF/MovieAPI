using MoviesAPI.Contexts;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories
{
    public class MovieRepository(AppDbContext appDbContext) : IMovieRepository
    {
        private readonly AppDbContext _context = appDbContext;

        public Result AddMovie(Movie movie)
        {
            try
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return new Result(true, "Success!");
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public Result DeleteMovie(int id)
        {
            try
            {
                _context.Movies.Remove(_context.Movies.First(m=>m.Id == id));
                _context.SaveChanges();
                return new Result(true, "Success!");
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public List<Movie> FindMovies(string key)
        {
            return _context.Movies
                .Where(m => m.Genre.ToLower().Contains(key) || m.Title.ToLower().Contains(key)).ToList();
        }

        public List<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetOneMovie(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id)??new Movie();
        }

        public Result UpdateMovie(Movie movie)
        {
            try
            {
                var oldMovie = _context.Movies.FirstOrDefault(m=>m.Id == movie.Id);
                if(oldMovie != null)
                {
                    _context.Entry(oldMovie).CurrentValues.SetValues(movie);
                    _context.SaveChanges();
                    return new Result(true, "Success!");
                }
                else return new Result(false, "No movie like this found");

            }
            catch (Exception ex)
            {

                return new Result(false, ex.Message);
            }
        }
    }
}
