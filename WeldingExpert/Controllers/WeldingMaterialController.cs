using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeldingExpert.Models;

namespace WeldingExpert.Controllers
{
    public class WeldingMaterialController : Controller
    {
        private DbContext db = new DbContext();

        public WeldingMaterialController()
        {
            ViewBag.CurrentController = "WeldingMaterial";
            ViewBag.Title = "焊材管理";
        }

        //
        // GET: /WeldingMaterial/

        public ActionResult Index()
        {
            return View(db.WeldingMaterials.ToList());
        }

        //
        // GET: /WeldingMaterial/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /WeldingMaterial/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /WeldingMaterial/Create

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
        // GET: /WeldingMaterial/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /WeldingMaterial/Edit/5

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
        // GET: /WeldingMaterial/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /WeldingMaterial/Delete/5

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
