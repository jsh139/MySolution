using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
	public class Movie
	{
		public int ID { get; set; }

		[Required]
		public string Title { get; set; }
		
		[DataType(DataType.Date)]
		public DateTime ReleaseDate { get; set; }

		[Required]
		public string Genre { get; set; }
		
		[Range(1,100)]
		[DataType(DataType.Currency)]
//		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal Price { get; set; }
		
		[StringLength(5)]
		public string Rating { get; set; }
	}

	public class MovieDBContext : DbContext
	{
		public IDbSet<Movie> Movies { get; set; }
	}
}