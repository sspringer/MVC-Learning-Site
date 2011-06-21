using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovie2.Models;

namespace MvcMovie2.Controllers
{ 
    public class MovieController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        //
        // GET: /Movie/

        public ViewResult Index()
        {
            return View(db.Movies.ToList());
        }

        //
        // GET: /Movie/Details/5

        public ActionResult Details(int id = 0)
        {
            Movie movie = db.Movies.Find(id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        //
        // GET: /Movie/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Movie/Create

        [HttpPost]
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
        // GET: /Movie/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Movie movie = db.Movies.Find(id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        //
        // POST: /Movie/Edit/5

        [HttpPost]
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
        // GET: /Movie/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Movie movie = db.Movies.Find(id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        //
        // POST: /Movie/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {            
            Movie movie = db.Movies.Find(id);

            if (movie == null)
                return HttpNotFound();

            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //
        // GET: /Movie/SearchIndex

        public ActionResult SearchIndex(string movieGenre, string searchString)
        {
            var genreList = new List<string>();

            var genreQuery = from m in db.Movies
                             orderby m.Genre
                             select m.Genre;

            genreList.AddRange(genreQuery.Distinct());
            ViewBag.movieGenre = new SelectList(genreList);

            var movies = from m in db.Movies
                         select m;

            if (!string.IsNullOrEmpty(searchString))
                movies = movies.Where(s => s.Title.Contains(searchString));

            if (string.IsNullOrEmpty(movieGenre))
                return View(movies);
            else
                return View(movies.Where(x => x.Genre == movieGenre));
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}