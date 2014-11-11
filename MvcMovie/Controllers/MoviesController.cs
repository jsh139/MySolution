using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

		public MoviesController()
		{
		}

		public MoviesController(MovieDBContext db)
		{
			this.db = db;
		}

        //
        // GET: /Movies/

        public ActionResult Index()
        {
            return View(db.Movies.OrderBy(m => m.Title).ToList());
        }

        //
        // GET: /Movies/Details/5

        public ActionResult Details(int? id)
        {
			if (id == null)
				return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            Movie movie = db.Movies.Find(id);
            
			if (movie == null)
                return HttpNotFound();
            
			return View(movie);
        }

        //
        // GET: /Movies/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Movies/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        //
        // GET: /Movies/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /Movies/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        //
        // GET: /Movies/Delete/5

        public ActionResult Delete(int? id)
        {
			if (id == null)
				return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            Movie movie = db.Movies.Find(id);
            
			if (movie == null)
                return HttpNotFound();
            
			return View(movie);
        }

        //
        // POST: /Movies/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

		//
		// GET: /Movies/SearchIndex?searchString=xxx
		public ActionResult SearchIndex(string movieGenre, string searchString)
		{
//			var GenreLst = new List<string>();

//			var GenreQry = (from d in db.Movies
//						   orderby d.Genre
//						   select d.Genre).Distinct();
//			GenreLst.AddRange(GenreQry);
			ViewBag.movieGenre = new SelectList((from d in db.Movies
												 orderby d.Genre
												 select d.Genre).Distinct().ToList());

			var movies = from m in db.Movies
						 select m;

			if (!String.IsNullOrEmpty(searchString))
			{
				movies = movies.Where(s => s.Title.Contains(searchString)).OrderBy(s => s.Title);
			}

			if (string.IsNullOrEmpty(movieGenre))
				return View(movies.OrderBy(x => x.Title));
			else
			{
				return View(movies.Where(x => x.Genre == movieGenre).OrderBy(x => x.Title));
			}
		}

    }
}