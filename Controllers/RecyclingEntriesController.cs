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
    public class RecyclingEntriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RecyclingEntries
        public ActionResult Index()
        {
            var recyclingEntries = db.RecyclingEntries.Include(r => r.DropOffPoint).Include(r => r.MaterialType);
            return View(recyclingEntries.ToList());
        }

        // GET: RecyclingEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecyclingEntry recyclingEntry = db.RecyclingEntries.Find(id);
            if (recyclingEntry == null)
            {
                return HttpNotFound();
            }
            return View(recyclingEntry);
        }
        //<Added
        //[Authorize(Roles = "Resident")]
        //Original>
        // GET: RecyclingEntries/Create
        public ActionResult Create()
        {
            ViewBag.DropOffPointId = new SelectList(db.DropOffPoints, "DropOffPointId", "Name");
            ViewBag.MaterialTypeId = new SelectList(db.MaterialTypes, "MaterialTypeId", "Name");
            return View();
        }

        // POST: RecyclingEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecyclingEntryId,MaterialTypeId,DropOffPointId,Weight,SubmissionDate,Status,Notes,UserId")] RecyclingEntry recyclingEntry)
        {
            if (ModelState.IsValid)
            {
                db.RecyclingEntries.Add(recyclingEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DropOffPointId = new SelectList(db.DropOffPoints, "DropOffPointId", "Name", recyclingEntry.DropOffPointId);
            ViewBag.MaterialTypeId = new SelectList(db.MaterialTypes, "MaterialTypeId", "Name", recyclingEntry.MaterialTypeId);
            return View(recyclingEntry);
        }
        //<Added
        //[Authorize(Roles = "Collection Officer")]
        //Original>
        // GET: RecyclingEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecyclingEntry recyclingEntry = db.RecyclingEntries.Find(id);
            if (recyclingEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.DropOffPointId = new SelectList(db.DropOffPoints, "DropOffPointId", "Name", recyclingEntry.DropOffPointId);
            ViewBag.MaterialTypeId = new SelectList(db.MaterialTypes, "MaterialTypeId", "Name", recyclingEntry.MaterialTypeId);
            return View(recyclingEntry);
        }

        // POST: RecyclingEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecyclingEntryId,MaterialTypeId,DropOffPointId,Weight,SubmissionDate,Status,Notes,UserId")] RecyclingEntry recyclingEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recyclingEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DropOffPointId = new SelectList(db.DropOffPoints, "DropOffPointId", "Name", recyclingEntry.DropOffPointId);
            ViewBag.MaterialTypeId = new SelectList(db.MaterialTypes, "MaterialTypeId", "Name", recyclingEntry.MaterialTypeId);
            return View(recyclingEntry);
        }
        //<Added
        //[Authorize(Roles = "Administrator")]
        //Original>
        // GET: RecyclingEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecyclingEntry recyclingEntry = db.RecyclingEntries.Find(id);
            if (recyclingEntry == null)
            {
                return HttpNotFound();
            }
            return View(recyclingEntry);
        }

        // POST: RecyclingEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecyclingEntry recyclingEntry = db.RecyclingEntries.Find(id);
            db.RecyclingEntries.Remove(recyclingEntry);
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
