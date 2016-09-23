using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeldingExpertSystem.Models;

namespace WeldingExpertSystem.Controllers
{
    public class ParentMetalController : Controller
    {
        private WeldingDbContext db = new WeldingDbContext();

        public ParentMetalController()
        {
            ViewBag.CurrentController = "ParentMetal";
            ViewBag.Title = "母材管理";
        }

        //
        // GET: /BaseMetal/

        public ActionResult Index()
        {
            return View(db.ParentMetalClasses.Include("Standards").ToList());
        }

        //
        // GET: /BaseMetal/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /BaseMetal/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /BaseMetal/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /BaseMetal/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /BaseMetal/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /BaseMetal/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /BaseMetal/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
