using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplicationCore.Models
{
    public class MovieRepository : IMovieRepository
    {
        MovieDbContext _movieDbContext = null;
        public MovieRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public bool AddMovie(MovieModel movie)
        {
            try
            {
                _movieDbContext.MovieModels.Add(movie);
                _movieDbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<MovieModel> SearchMovie(MovieModel movieModel)
        {
            List<MovieModel> movieModelslist = (from result in _movieDbContext.MovieModels.AsEnumerable()
                                                where result.MovieName == movieModel.MovieName &&
                                                result.Description == movieModel.Description &&
                                                result.MovieLangauge == movieModel.MovieLangauge select result).ToList();
            return movieModelslist;
        }
    }
}
