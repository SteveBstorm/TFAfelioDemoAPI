using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IMovieRepo
    {
        void Create(Movie m);
        Movie GetById(int id);
        IEnumerable<Movie> GetAll();
        void Update(Movie m);
        void Delete(int id);
    }
}
