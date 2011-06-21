using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie2.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required(ErrorMessage="The movie title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The movie release date is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "The movie genre must be specified")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "The movie price is required")]
        [Range(1, 100, ErrorMessage = "The movie price must be between $1 and $100")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [StringLength(5)]
        public string Rating { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}
