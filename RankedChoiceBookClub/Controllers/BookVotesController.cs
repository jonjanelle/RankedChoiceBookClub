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
    public class BookVotesController : Controller
    {
        private RankedChoiceBookClubContext db = new RankedChoiceBookClubContext();

        // GET: BookVotes
        public ActionResult Index()
        {
            return View(db.BookVotes.ToList());
        }

        // GET: BookVotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookVote bookVote = db.BookVotes.Find(id);
            if (bookVote == null)
            {
                return HttpNotFound();
            }
            return View(bookVote);
        }

        // GET: BookVotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookVotes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] BookVote bookVote)
        {
            if (ModelState.IsValid)
            {
                db.BookVotes.Add(bookVote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookVote);
        }

        // GET: BookVotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookVote bookVote = db.BookVotes.Find(id);
            if (bookVote == null)
            {
                return HttpNotFound();
            }
            return View(bookVote);
        }

        // POST: BookVotes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] BookVote bookVote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookVote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookVote);
        }

        // GET: BookVotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookVote bookVote = db.BookVotes.Find(id);
            if (bookVote == null)
            {
                return HttpNotFound();
            }
            return View(bookVote);
        }

        // POST: BookVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookVote bookVote = db.BookVotes.Find(id);
            db.BookVotes.Remove(bookVote);
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
