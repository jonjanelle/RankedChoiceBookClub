using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RankedChoiceBookClub.Models;


namespace RankedChoiceBookClub.Controllers
{
    public class BookClubsController : Controller
    {
        private RankedChoiceBookClubContext db = new RankedChoiceBookClubContext();

        // GET: BookClubs
        public ActionResult Index()
        {
            return View(db.BookClubs.ToList());
        }

        // GET: BookClubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookClub bookClub = db.BookClubs.Find(id);
            if (bookClub == null)
            {
                return HttpNotFound();
            }
            return View(bookClub);
        }

        // GET: BookClubs/New
        public ActionResult New()
        {
            return View();
        }

        // POST: BookClubs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AccessCode,Description")] BookClub bookClub)
        {
            if (ModelState.IsValid)
            {
                db.BookClubs.Add(bookClub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookClub);
        }

        // GET: BookClubs/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookClub bookClub = db.BookClubs.Find(id);
            if (bookClub == null)
            {
                return HttpNotFound();
            }
            return View(bookClub);
        }

        // POST: BookClubs/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AccessCode,Description")] BookClub bookClub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookClub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookClub);
        }

        // GET: BookClubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookClub bookClub = db.BookClubs.Find(id);
            if (bookClub == null)
            {
                return HttpNotFound();
            }
            return View(bookClub);
        }

        // POST: BookClubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookClub bookClub = db.BookClubs.Find(id);
            db.BookClubs.Remove(bookClub);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
