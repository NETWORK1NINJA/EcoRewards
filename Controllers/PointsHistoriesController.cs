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
    public class PointsHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PointsHistories
        public ActionResult Index()
        {
            var pointsHistories = db.PointsHistories.Include(p => p.RecyclingEntry);
            return View(pointsHistories.ToList());
        }

        // GET: PointsHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointsHistory pointsHistory = db.PointsHistories.Find(id);
            if (pointsHistory == null)
            {
                return HttpNotFound();
            }
            return View(pointsHistory);
        }

        // GET: PointsHistories/Create
        public ActionResult Create()
        {
            ViewBag.RecyclingEntryId = new SelectList(db.RecyclingEntries, "RecyclingEntryId", "Status");
            return View();
        }

        // POST: PointsHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PointsHistoryId,RecyclingEntryId,PointsEarned,DateAwarded")] PointsHistory pointsHistory)
        {
            if (ModelState.IsValid)
            {
                db.PointsHistories.Add(pointsHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecyclingEntryId = new SelectList(db.RecyclingEntries, "RecyclingEntryId", "Status", pointsHistory.RecyclingEntryId);
            return View(pointsHistory);
        }

        // GET: PointsHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointsHistory pointsHistory = db.PointsHistories.Find(id);
            if (pointsHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecyclingEntryId = new SelectList(db.RecyclingEntries, "RecyclingEntryId", "Status", pointsHistory.RecyclingEntryId);
            return View(pointsHistory);
        }

        // POST: PointsHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PointsHistoryId,RecyclingEntryId,PointsEarned,DateAwarded")] PointsHistory pointsHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pointsHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecyclingEntryId = new SelectList(db.RecyclingEntries, "RecyclingEntryId", "Status", pointsHistory.RecyclingEntryId);
            return View(pointsHistory);
        }

        // GET: PointsHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PointsHistory pointsHistory = db.PointsHistories.Find(id);
            if (pointsHistory == null)
            {
                return HttpNotFound();
            }
            return View(pointsHistory);
        }

        // POST: PointsHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PointsHistory pointsHistory = db.PointsHistories.Find(id);
            db.PointsHistories.Remove(pointsHistory);
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
