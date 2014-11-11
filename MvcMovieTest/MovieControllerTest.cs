using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Controllers;
using MvcMovie.Models;
using Moq;
using Xunit;
using FakeDbSet;

namespace MvcMovieTest
{
	public class MovieControllerTest
	{
		[Fact]
		public void TestIndex()
		{
			const string ViewName = "Index";

			var mov = new InMemoryDbSet<Movie>();
			var db = new Mock<MovieDBContext>();
			db.Setup(d => d.Movies).Returns(mov);
			
			var m = new MoviesController(db.Object);
			var View = m.Index() as ViewResult;

			Assert.NotNull(View);
			Assert.Equal(ViewName, View.ViewName);
		}

		[Fact]
		public void TestCreate()
		{
			const string ViewName = "Create";
			var MovCtrl = new MoviesController();

			var View = MovCtrl.Create() as ViewResult;

			Assert.NotNull(View);
			Assert.Equal(ViewName, View.ViewName);
		}
	}


}
