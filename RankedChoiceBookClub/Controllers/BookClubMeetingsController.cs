using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RankedChoiceBookClub.Models;
using RankedChoiceBookClub.ViewModels;
namespace RankedChoiceBookClub.Controllers
{
    public class BookClubMeetingsController : Controller
    {
        private RankedChoiceBookClubContext db = new RankedChoiceBookClubContext();

        // GET: BookClubMeetings
        public ActionResult Index()
        {
            return View(db.BookClubMeetings.ToList());
        }

        // GET: BookClubMeetings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookClubMeeting bookClubMeeting = db.BookClubMeetings.Find(id);
            if (bookClubMeeting == null)
            {
                return HttpNotFound();
            }
            return View(bookClubMeeting);
        }

        // GET: BookClubMeetings/Create
        public ViewResult Create()
        { 
            BookClubMeetingFormVM NewMeetingVM = new BookClubMeetingFormVM();
            NewMeetingVM.BookClubMeeting = new BookClubMeeting();
            //ToList to immediate execute the query rather than waiting to perform in view/viewmodel
            NewMeetingVM.BookOptions = db.Books.ToList();
            //Eventually a book club id should be a required arugment, only should be allowed to access this action if administrator of book club
            NewMeetingVM.BookClubs = db.BookClubs.ToList();
            return View(NewMeetingVM);
        }

        // POST: BookClubMeetings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date")] BookClubMeeting bookClubMeeting)
        {
            if (ModelState.IsValid)
            {
                db.BookClubMeetings.Add(bookClubMeeting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
    
            return View(bookClubMeeting);
        }

        // GET: BookClubMeetings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookClubMeeting bookClubMeeting = db.BookClubMeetings.Find(id);
            if (bookClubMeeting == null)
            {
                return HttpNotFound();
            }
            return View(bookClubMeeting);
        }

        // POST: BookClubMeetings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date")] BookClubMeeting bookClubMeeting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookClubMeeting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookClubMeeting);
        }

        // GET: BookClubMeetings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookClubMeeting bookClubMeeting = db.BookClubMeetings.Find(id);
            if (bookClubMeeting == null)
            {
                return HttpNotFound();
            }
            return View(bookClubMeeting);
        }

        // POST: BookClubMeetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookClubMeeting bookClubMeeting = db.BookClubMeetings.Find(id);
            db.BookClubMeetings.Remove(bookClubMeeting);
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
