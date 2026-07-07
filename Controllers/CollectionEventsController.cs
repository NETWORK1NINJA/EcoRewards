using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcoRewards.Models;

namespace EcoRewards.Controllers
{
    public class CollectionEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CollectionEvents
        public ActionResult Index()
        {
            return View(db.CollectionEvents.ToList());
        }

        // GET: CollectionEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionEvent collectionEvent = db.CollectionEvents.Find(id);
            if (collectionEvent == null)
            {
                return HttpNotFound();
            }
            return View(collectionEvent);
        }

        // GET: CollectionEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CollectionEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CollectionEventId,EventName,EventDate,Location,Description,IsActive")] CollectionEvent collectionEvent)
        {
            if (ModelState.IsValid)
            {
                db.CollectionEvents.Add(collectionEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(collectionEvent);
        }

        // GET: CollectionEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionEvent collectionEvent = db.CollectionEvents.Find(id);
            if (collectionEvent == null)
            {
                return HttpNotFound();
            }
            return View(collectionEvent);
        }

        // POST: CollectionEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CollectionEventId,EventName,EventDate,Location,Description,IsActive")] CollectionEvent collectionEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collectionEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(collectionEvent);
        }

        // GET: CollectionEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionEvent collectionEvent = db.CollectionEvents.Find(id);
            if (collectionEvent == null)
            {
                return HttpNotFound();
            }
            return View(collectionEvent);
        }

        // POST: CollectionEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CollectionEvent collectionEvent = db.CollectionEvents.Find(id);
            db.CollectionEvents.Remove(collectionEvent);
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
