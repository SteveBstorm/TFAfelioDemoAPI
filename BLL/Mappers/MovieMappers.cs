using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLLM = BLL.Models;
using DALM = DAL.Models;


namespace BLL.Mappers
{
    public static class MovieMappers
    {
        public static BLLM.Movie ToBll(this DALM.Movie movie)
        {
            return new BLLM.Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Synopsis = movie.Synopsis,
                PEGI = movie.PEGI,
                ReleaseYear = movie.ReleaseYear
            };
        }

        public static DALM.Movie ToDal(this BLLM.Movie movie)
        {
            return new DALM.Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Synopsis = movie.Synopsis,
                PEGI = movie.PEGI,
                ReleaseYear = movie.ReleaseYear
            };
        }

        public static BLLM.User ToBll(this DALM.User u)
        {
            return new BLLM.User
            {
                Id = u.Id,
                NickName = u.NickName,
                Email = u.Email,
                IsAdmin = u.IsAdmin
            };
        }
    }
}
