using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SecretSantaDraw.Models;
using SecretSantaDraw.DAL;

namespace SecretSantaDraw.Controllers
{
    public class DrawController : Controller
    {
        private readonly SecretSantaDrawContext db = new SecretSantaDrawContext();

        public ActionResult Index()
        {
            var draws = db.Draws.Include(d => d.Owner);
            return View(draws.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Draw draw = db.Draws.Find(id);
            if (draw == null)
            {
                return HttpNotFound();
            }
            return View(draw);
        }

        public ActionResult Create(int profileId)
        {
            var draw = new Draw {OwnerId = profileId};
            return View(draw);
        }

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

        public ActionResult Delete(int id = 0)
        {
            Draw draw = db.Draws.Find(id);
            if (draw == null)
            {
                return HttpNotFound();
            }
            return View(draw);
        }

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