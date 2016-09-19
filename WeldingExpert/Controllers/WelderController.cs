using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeldingExpert.Models;

namespace WeldingExpert.Controllers
{ 
    public class WelderController : Controller
    {
        private DbContext db = new DbContext();

        //
        // GET: /Welder/

        public ViewResult Index()
        {
            return View(db.Welders.ToList());
        }

        //
        // GET: /Welder/Details/5

        public ViewResult Details(string id)
        {
            Welder welder = db.Welders.Find(id);
            return View(welder);
        }

        //
        // GET: /Welder/Create

        public ActionResult Create()
        {
            ViewBag.WelderLevels = Enum<WelderLevel>.GetSelectList();

            List<int> years = new List<int>();

            for (int i = 1940; i < 2010; i++)
            {
                years.Add(i);
            }

            ViewBag.Years = new SelectList(years);
            return View();
        } 

        //
        // POST: /Welder/Create

        [HttpPost]
        public ActionResult Create(Welder welder)
        {
            if (ModelState.IsValid)
            {
                db.Welders.Add(welder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WelderLevels = Enum<WelderLevel>.GetSelectList();

            List<int> years = new List<int>();

            for (int i = 1940; i < 2010; i++)
            {
                years.Add(i);
            }

            ViewBag.Years = new SelectList(years);
            return View(welder);
        }
        
        //
        // GET: /Welder/Edit/5
 
        public ActionResult Edit(string id)
        {
            Welder welder = db.Welders.Find(id);
            return View(welder);
        }

        //
        // POST: /Welder/Edit/5

        [HttpPost]
        public ActionResult Edit(Welder welder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(welder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(welder);
        }

        //
        // GET: /Welder/Delete/5
 
        public ActionResult Delete(string id)
        {
            Welder welder = db.Welders.Find(id);
            return View(welder);
        }

        //
        // POST: /Welder/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            Welder welder = db.Welders.Find(id);
            db.Welders.Remove(welder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}