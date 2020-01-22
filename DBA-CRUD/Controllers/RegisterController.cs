using DBA_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBA_CRUD.Controllers
{
    public class RegisterController : Controller
    {

        DBAEntities db = new DBAEntities();
        // GET: Register
        public ActionResult SetDatainDatabase()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetDataInDataBase(LoginPanel model)
        {
            LoginPanel tbl = new LoginPanel();
            tbl.Username = model.Username;
            tbl.Password = model.Password;
            db.LoginPanels.Add(tbl);
            db.SaveChanges();
            return View();
        }
        public ActionResult ShowDataBaseForUser()
        {
            var item = db.LoginPanels.ToList();
            return View(item);
        }
        public ActionResult Delete(int id)
        {
            //var item = db.LoginPanels.Where(x => x.ID == id).First();
            var item = db.LoginPanels.FirstOrDefault(x => x.ID.Equals(id));
            if (item != null)
            {
                db.LoginPanels.Remove(item);
                db.SaveChanges();
            }
            var item2 = db.LoginPanels.ToList();
            return View("ShowDataBaseForUser", item2);
        }
        public ActionResult Edit(int id)
        {
            var item = db.LoginPanels.Where(x => x.ID == id).First();
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(LoginPanel model)
        {
            var item = db.LoginPanels.Where(x => x.ID == model.ID).First();
            item.Username = model.Username;
            item.Password = model.Password;
            db.SaveChanges();
            var item2 = db.LoginPanels.ToList();
            return View("ShowDataBaseForUser", item2);
        }
    }
}