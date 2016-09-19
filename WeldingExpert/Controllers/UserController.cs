using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeldingExpert.Models;

namespace WeldingExpert.Controllers
{
    public class UserController : Controller
    {
        private DbContext db = new DbContext();

        public UserController()
        {
            ViewBag.CurrentController = "User";
            ViewBag.Title = "用户管理";
        }

        public ActionResult Index()
        {
            string usrname = Session["usr-name"] as string;
            if (usrname == null)
                return RedirectToAction("Index", "Home");

            User usr = db.Users.Find(usrname);
            return View(usr);
        }

        public ActionResult All()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.Roles = UserRole.GetSelectList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateUserModel usr)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Find(usr.UserName) != null)
                {
                    ModelState.AddModelError("", "用户已存在");
                }
                else
                {
                    db.Users.Add(usr.ToUser());
                    db.SaveChanges();
                    return RedirectToAction("CreatedOK", usr.ToCreateUserOkModel());
                }
            }

            ViewBag.Roles = UserRole.GetSelectList();
            return View();
        }

        public ActionResult CreatedOK(CreateUserOkModel usr)
        {
            ViewBag.Roles = UserRole.GetSelectList();
            return View(usr);
        }

        public ActionResult DeletedOK(DeleteUserModel usr)
        {
            ViewBag.Roles = UserRole.GetSelectList();
            return View(usr);
        }

        public ActionResult Delete(string usrname)
        {
            User usr = db.Users.Find(usrname);
            return View(usr.ToDeleteUserModel());
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string usrname)
        {
            User usr = db.Users.Find(usrname);
            db.Users.Remove(usr);
            db.SaveChanges();
            return RedirectToAction("DeletedOK", usr.ToDeleteUserModel());
        }
    }
}
