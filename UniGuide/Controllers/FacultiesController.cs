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
    public class FacultiesController : BaseController
    {
        private UniGuideEntities db = new UniGuideEntities();

        // GET: Faculties
        public async Task<ActionResult> Index()
        {
            var faculties = db.Faculties.Include(f => f.AdmissionType1).Include(f => f.City1).Include(f => f.Hybird1).Include(f => f.University);
            return View(await faculties.ToListAsync());
        }

        // GET: Faculties/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = await db.Faculties.FindAsync(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // GET: Faculties/Create
        public ActionResult Create()
        {
            ViewBag.AdmissionType = new SelectList(db.AdmissionTypes, "AdmisionID", "AdmisionEng");
            ViewBag.City = new SelectList(db.Cities, "CityID", "CityEng");
            ViewBag.Hybird = new SelectList(db.Hybirds, "HybirdID", "HybirdEng");
            ViewBag.UniversityID = new SelectList(db.Universities, "UniveristyID", "UniversityEng");
            return View();
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FacultyID,FacultyEng,FacultyArb,AboutEng,AboutArb,logo,City,Location,CreateDate,FacultyURL,AdmissionType,Hybird,UniversityID")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                db.Faculties.Add(faculty);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AdmissionType = new SelectList(db.AdmissionTypes, "AdmisionID", "AdmisionEng", faculty.AdmissionType);
            ViewBag.City = new SelectList(db.Cities, "CityID", "CityEng", faculty.City);
            ViewBag.Hybird = new SelectList(db.Hybirds, "HybirdID", "HybirdEng", faculty.Hybird);
            ViewBag.UniversityID = new SelectList(db.Universities, "UniveristyID", "UniversityEng", faculty.UniversityID);
            return View(faculty);
        }

        // GET: Faculties/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = await db.Faculties.FindAsync(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdmissionType = new SelectList(db.AdmissionTypes, "AdmisionID", "AdmisionEng", faculty.AdmissionType);
            ViewBag.City = new SelectList(db.Cities, "CityID", "CityEng", faculty.City);
            ViewBag.Hybird = new SelectList(db.Hybirds, "HybirdID", "HybirdEng", faculty.Hybird);
            ViewBag.UniversityID = new SelectList(db.Universities, "UniveristyID", "UniversityEng", faculty.UniversityID);
            return View(faculty);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FacultyID,FacultyEng,FacultyArb,AboutEng,AboutArb,logo,City,Location,CreateDate,FacultyURL,AdmissionType,Hybird,UniversityID")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AdmissionType = new SelectList(db.AdmissionTypes, "AdmisionID", "AdmisionEng", faculty.AdmissionType);
            ViewBag.City = new SelectList(db.Cities, "CityID", "CityEng", faculty.City);
            ViewBag.Hybird = new SelectList(db.Hybirds, "HybirdID", "HybirdEng", faculty.Hybird);
            ViewBag.UniversityID = new SelectList(db.Universities, "UniveristyID", "UniversityEng", faculty.UniversityID);
            return View(faculty);
        }

        // GET: Faculties/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = await db.Faculties.FindAsync(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Faculty faculty = await db.Faculties.FindAsync(id);
            db.Faculties.Remove(faculty);
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
