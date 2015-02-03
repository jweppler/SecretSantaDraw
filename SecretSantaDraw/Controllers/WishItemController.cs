using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SecretSantaDraw.Models;
using SecretSantaDraw.DAL;
using SecretSantaDraw.ViewModels;

namespace SecretSantaDraw.Controllers
{
    public class WishItemController : Controller
    {
        private SecretSantaDrawContext db = new SecretSantaDrawContext();

        public ActionResult Index()
        {
            var wishitem = db.WishItem.Include(w => w.Profile);
            return View(wishitem.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            WishItem wishitem = db.WishItem.Find(id);
            if (wishitem == null)
            {
                return HttpNotFound();
            }
            return View(wishitem);
        }

        public ActionResult Create(int profileId)
        {
            var profile = db.Profile.Find(profileId);
            if (profile == null)
            {
                return HttpNotFound();
            }
            var viewModel = new WishItemListViewModel
            {
                ProfileId = profile.ProfileId,
                ProfileDisplayName = profile.DisplayName,
                WishList = profile.WishList
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(WishItem wishItem, int profileId = 0)
        {
            Profile profile = db.Profile.Find(profileId);
            if (profile == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                wishItem.ProfileId = profile.ProfileId;
                db.WishItem.Add(wishItem);
                db.SaveChanges();
                return RedirectToAction("Create", new { profileId });
            }

            var viewModel = new WishItemListViewModel
            {
                ProfileId = profile.ProfileId,
                ProfileDisplayName = profile.DisplayName,
                WishList = profile.WishList
            };
            return View(viewModel);
        }

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

        [HttpPost]
        public ActionResult Edit(WishItem wishitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wishitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create", new { profileId = wishitem.ProfileId });
            }
            ViewBag.ProfileId = new SelectList(db.Profile, "ProfileId", "DisplayName", wishitem.ProfileId);
            return View(wishitem);
        }

        public ActionResult Delete(int id = 0)
        {
            WishItem wishitem = db.WishItem.Find(id);
            if (wishitem == null)
            {
                return HttpNotFound();
            }
            return View(wishitem);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WishItem wishitem = db.WishItem.Find(id);
            db.WishItem.Remove(wishitem);
            db.SaveChanges();
            return RedirectToAction("Edit", new { profileId = wishitem.ProfileId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}