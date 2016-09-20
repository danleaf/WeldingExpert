using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeldingExpert.Models;

namespace WeldingExpert.Controllers
{
    public class HomeController : Controller
    {
        private DbContext db = new DbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LogOnModel model)
        {
            if (ModelState.IsValid)
            {
                User usr = db.Users.Find(model.UserName);
                if (usr != null && usr.Password == model.Password)
                {
                    HttpContext.Session["usr-name"] = usr.UserName;
                    HttpContext.Session["usr-role"] = usr.Role;
                    return RedirectToAction("Index", "ParentMetal");
                }
                else
                {
                    ModelState.AddModelError("", "提供的用户名或密码不正确。");
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View();
        }

        public ActionResult LogOff()
        {
            HttpContext.Session["usr-name"] = null;
            HttpContext.Session["usr-role"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.CurrentController = "Quality";

            return View();
        }

        public ActionResult CreateDefaultAdmin()
        {
            if (ModelState.IsValid)
            {
                var admin = from usr in db.Users where usr.UserName == "admin" select usr;
                if (admin.Count() > 0)
                    db.Users.Remove(admin.First());
                db.Users.Add(new User() { UserName = "admin", Password = "admin", Role = (int)UserRole.Admin, RealName = "叶丹", WorkerID = 1 });
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowPic()
        {
            return PartialView("_ShowPic");
        }        
    }
}
