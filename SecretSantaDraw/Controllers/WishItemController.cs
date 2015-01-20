using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecretSantaDraw.Models;
using SecretSantaDraw.DAL;

namespace SecretSantaDraw.Controllers
{
    public class WishItemController : Controller
    {
        private SecretSantaDrawContext db = new SecretSantaDrawContext();

        //
        // GET: /WishItem/

        public ActionResult Index()
        {
            var wishitem = db.WishItem.Include(w => w.Profile);
            return View(wishitem.ToList());
        }

        //
        // GET: /WishItem/Details/5

        public ActionResult Details(int id = 0)
        {
            WishItem wishitem = db.WishItem.Find(id);
            if (wishitem == null)
            {
                return HttpNotFound();
            }
            return View(wishitem);
        }

        //
        // GET: /WishItem/Create

        public ActionResult Create()
        {
            ViewBag.ProfileId = new SelectList(db.Profile, "ProfileId", "DisplayName");
            return View();
        }

        //
        // POST: /WishItem/Create

        [HttpPost]
        public ActionResult Create(WishItem wishitem)
        {
            if (ModelState.IsValid)
            {
                db.WishItem.Add(wishitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfileId = new SelectList(db.Profile, "ProfileId", "DisplayName", wishitem.ProfileId);
            return View(wishitem);
        }

        //
        // GET: /WishItem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WishItem wishitem = db.WishItem.Find(id);
            if (wishitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfileId = new SelectList(db.Profile, "ProfileId", "DisplayName", wishitem.ProfileId);
            return View(wishitem);
        }

        //
        // POST: /WishItem/Edit/5

        [HttpPost]
        public ActionResult Edit(WishItem wishitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wishitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EditWishList", "Profile", new { id = wishitem.ProfileId });
            }
            ViewBag.ProfileId = new SelectList(db.Profile, "ProfileId", "DisplayName", wishitem.ProfileId);
            return View(wishitem);
        }

        //
        // GET: /WishItem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WishItem wishitem = db.WishItem.Find(id);
            if (wishitem == null)
            {
                return HttpNotFound();
            }
            return View(wishitem);
        }

        //
        // POST: /WishItem/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WishItem wishitem = db.WishItem.Find(id);
            db.WishItem.Remove(wishitem);
            db.SaveChanges();
            return RedirectToAction("EditWishList", "Profile", new { id = wishitem.ProfileId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}