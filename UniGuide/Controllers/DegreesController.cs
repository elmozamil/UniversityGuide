using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniGuide.Models;

namespace UniGuide.Controllers
{
    public class DegreesController : BaseController
    {
        private UniGuideEntities db = new UniGuideEntities();

        // GET: Degrees
        public async Task<ActionResult> Index()
        {
            return View(await db.Degrees.ToListAsync());
        }

        // GET: Degrees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = await db.Degrees.FindAsync(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // GET: Degrees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Degrees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DegreeID,DegreeEng,DegreeArb")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                db.Degrees.Add(degree);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(degree);
        }

        // GET: Degrees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = await db.Degrees.FindAsync(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DegreeID,DegreeEng,DegreeArb")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degree).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(degree);
        }

        // GET: Degrees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = await db.Degrees.FindAsync(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Degree degree = await db.Degrees.FindAsync(id);
            db.Degrees.Remove(degree);
            await db.SaveChangesAsync();
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
