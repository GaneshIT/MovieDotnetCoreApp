using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplicationCore.Models
{
    interface IMovieRepository
    {
        bool AddMovie(MovieModel movie);
        List<MovieModel> SearchMovie(MovieModel movieModel);
    }
}
