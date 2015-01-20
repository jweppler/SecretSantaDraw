using System.Data;
using System.Linq;
using System.Web.Mvc;
using SecretSantaDraw.Models;
using SecretSantaDraw.DAL;

namespace SecretSantaDraw.Controllers
{
    public class ProfileController : Controller
    {
        private readonly SecretSantaDrawContext db = new SecretSantaDrawContext();

        //
        // GET: /Profile/

        public ActionResult Index()
        {
            return View(db.Profile.ToList());
        }

        //
        // GET: /Profile/Details/5

        public ActionResult Details(int id = 0)
        {
            var profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // GET: /Profile/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Profile/Create

        [HttpPost]
        public ActionResult Create(Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Profile.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        //
        // GET: /Profile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // POST: /Profile/Edit/5

        [HttpPost]
        public ActionResult Edit(Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        //
        // GET: /Profile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // POST: /Profile/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profile.Find(id);
            db.Profile.Remove(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Profile/EditWishList/5

        public ActionResult EditWishList(int id = 0)
        {
            var profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // POST: /Profile/EditWishList/5
        [HttpPost]
        public ActionResult EditWishList(WishItem wishItem, int id=0)
        {
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                wishItem.ProfileId = profile.ProfileId;
                db.WishItem.Add(wishItem);
                db.SaveChanges();
                return RedirectToAction("EditWishList", new {id = id});
            }
            return View(profile);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}