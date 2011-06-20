using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MvcMovie2.Models
{
    public class MovieInitializer : DropCreateDatabaseIfModelChanges<MovieDBContext>
    {
        protected override void Seed(MovieDBContext context)
        {
            var movies = new List<Movie>()
            {
                new Movie {
                    Title = "Glory",
                    Genre = "Drama",
                    ReleaseDate = DateTime.Parse("12/15/1989"),
                    Rating = "R",
                    Price = 7.99M
                },
                new Movie {
                    Title = "Blues Brothers",
                    Genre = "Comedy",
                    ReleaseDate = DateTime.Parse("6/20/1980"),
                    Rating = "R",
                    Price = 9.99M
                },
                new Movie {
                    Title = "Animal House",
                    Genre = "Comedy",
                    ReleaseDate = DateTime.Parse("7/28/1978"),
                    Rating = "R",
                    Price = 7.99M
                }
            };

            movies.ForEach(d => context.Movies.Add(d));
        }
    }
}