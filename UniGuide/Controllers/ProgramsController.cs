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
    public class ProgramsController : BaseController
    {
        private UniGuideEntities db = new UniGuideEntities();

        // GET: Programs
        public async Task<ActionResult> Index()
        {
            var programs = db.Programs.Include(p => p.Faculty).Include(p => p.Degree);
            return View(await programs.ToListAsync());
        }


        public ActionResult SearchProgramsByDegree(int degree, int adType, int city)
        {
            var program = (from p in db.Programs
                           join f in db.Faculties on p.FacultyID equals f.FacultyID
                           where f.City == city &&  f.AdmissionType == adType && p.DegreeID == degree 
                           select p).ToList();

            return View(program);
        }



        public ActionResult SearchProgramsByCat(int decipline, int period)
        {
            var program = (from p in db.Programs
                           from dp in p.Diciplines
                           where dp.DiciID == decipline && p.Period == period
                           select p).ToList();

            return View(program);

        }
        // GET: Programs/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = await db.Programs.FindAsync(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // GET: Programs/Create
        public ActionResult Create()
        {
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyEng");
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "DegreeEng");
            return View();
        }

        // POST: Programs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProgramID,ProgramEng,ProgramArb,AboutEng,AboutArb,Period,Semesters,ProgramURL,FacultyID,DegreeID")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Programs.Add(program);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyEng", program.FacultyID);
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "DegreeEng", program.DegreeID);
            return View(program);
        }

        // GET: Programs/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = await db.Programs.FindAsync(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyEng", program.FacultyID);
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "DegreeEng", program.DegreeID);
            return View(program);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProgramID,ProgramEng,ProgramArb,AboutEng,AboutArb,Period,Semesters,ProgramURL,FacultyID,DegreeID")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyEng", program.FacultyID);
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "DegreeEng", program.DegreeID);
            return View(program);
        }

        // GET: Programs/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = await db.Programs.FindAsync(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Program program = await db.Programs.FindAsync(id);
            db.Programs.Remove(program);
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
