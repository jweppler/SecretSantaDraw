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
    public class DrawController : Controller
    {
        private SecretSantaDrawContext db = new SecretSantaDrawContext();

        //
        // GET: /Draw/

        public ActionResult Index()
        {
            var draws = db.Draws.Include(d => d.Owner);
            return View(draws.ToList());
        }

        //
        // GET: /Draw/Details/5

        public ActionResult Details(int id = 0)
        {
            Draw draw = db.Draws.Find(id);
            if (draw == null)
            {
                return HttpNotFound();
            }
            return View(draw);
        }

        //
        // GET: /Draw/Create

        public ActionResult Create(int profileId)
        {
            var draw = new Draw {OwnerId = profileId};
            return View(draw);
        }

        //
        // POST: /Draw/Create

        [HttpPost]
        public ActionResult Create(Draw draw)
        {
            if (ModelState.IsValid)
            {
                db.Draws.Add(draw);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(draw);
        }

        //
        // GET: /Draw/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Draw draw = db.Draws.Find(id);
            if (draw == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Profile, "ProfileId", "DisplayName", draw.OwnerId);
            return View(draw);
        }

        //
        // POST: /Draw/Edit/5

        [HttpPost]
        public ActionResult Edit(Draw draw)
        {
            if (ModelState.IsValid)
            {
                db.Entry(draw).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Profile, "ProfileId", "DisplayName", draw.OwnerId);
            return View(draw);
        }

        //
        // GET: /Draw/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Draw draw = db.Draws.Find(id);
            if (draw == null)
            {
                return HttpNotFound();
            }
            return View(draw);
        }

        //
        // POST: /Draw/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Draw draw = db.Draws.Find(id);
            db.Draws.Remove(draw);
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