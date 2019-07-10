using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;  //get the Model
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()//ViewResult Random()   
        { 
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer> { new Customer { Name = "Customer1" }, new Customer { Name = "Customer2" } };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                CustomerList = customers
            };
            return View(viewModel);

            //return View(movie);

            //OR   not ok for renaming
            //ViewData["Movie"] = movie;
            //return View();
           
            
            //OR
            // return new ViewResult();
            //return Content("hello world");
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        } 

        public ActionResult Edit(int id)    //movieId ->err pt ca id e de fapt numele din RouteConfig
        {
            
            return Content("id= " + id);
        }

        //movies
        public ActionResult Index(int? pageIndex, string sortBy)  // no pageIndex -> diplay will be in page 1
            //sortBy not ->specfied will be sorted by name
            //int? to make it nullable
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if(String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        }

        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content("year= " + year + "month" + month);
        //}

        // regex is not a string !!! need //d
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content("year= " + year + "month" + month);
        }



    }
    
}