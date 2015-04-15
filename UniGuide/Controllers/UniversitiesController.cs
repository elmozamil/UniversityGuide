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
using System.IO;

namespace UniGuide.Controllers
{
    public class UniversitiesController : BaseController
    {
        private const int pagesize = 10;
        private UniGuideEntities db = new UniGuideEntities();

        // GET: Universities
        public async Task<ActionResult> Index()
        {
            var universities = db.Universities.Include(u => u.City1);
            return View(await universities.ToListAsync());
        }

        //public async Task<ActionResult> List(int? entryCount)
        public ActionResult List(int? entryCount)
        {
            if (!entryCount.HasValue)
                entryCount = 1;

            int skipRows = (entryCount.Value - 1) * pagesize;

            if (Request.IsAjaxRequest())
            {
                var Pagedresult = (from uni in db.Universities
                                   orderby uni.GlobalRank descending
                                   select uni).Skip(skipRows).Take(pagesize).ToList();

                if (Pagedresult.Count() > 0)
                {
                    AddMoreUrlToViewData(entryCount.Value);
                }
                return PartialView("PartialUniList", Pagedresult);
            }

            var result = (from uni in db.Universities
                          orderby uni.GlobalRank descending
                          select uni).Skip(skipRows).Take(pagesize).ToList();

            if (result.Count > 0)
            {
                AddMoreUrlToViewData(entryCount.Value);
            }
            return View(result);
            //var universities = db.Universities.Include(u => u.City1);
            //return View(await universities.ToListAsync());
        }

        private void AddMoreUrlToViewData(int entryCount)
        {
            ViewData["moreUrl"] = Url.Action("List", "Universities", new { entryCount = entryCount + 1 });
            ViewBag.moreUrl = Url.Action("List", "Universities", new { entryCount = entryCount + 1 });
        }

        // GET: Universities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = await db.Universities.FindAsync(id);
            if (university == null)
            {
                return HttpNotFound();
            }

            //var ProgramsInUni = from u in db.Universities
            //                 join f in db.Faculties on u.UniveristyID equals f.UniversityID
            //                 join p in db.Programs on f.FacultyID equals p.FacultyID
            //                 where u.UniveristyID == id
            //                 select new { f, u };
            //ViewBag.NoProg = ProgramsInUni.Count();

            return View(university);
        }

        // GET: Universities/Create
        public ActionResult Create()
        {
            ViewBag.City = new SelectList(db.Cities, "CityID", "CityEng");
            return View();
        }

        // POST: Universities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "UniveristyID,UniversityEng,UniversityArb,AboutUniversityEng,AboutUniversityArb,City,Location,logo,CreatedDate,UniversityURL,GlobalRank,ContinetRank,RegionalRank,LocalRank")] University university)
        public async Task<ActionResult> Create([Bind(Exclude = "logo")] University university, HttpPostedFileBase logo)
        {

            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (logo == null || logo.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!validImageTypes.Contains(logo.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image");
            }

            byte[] data;
            using (Stream inputStream = logo.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            university.logo = data;

            if (ModelState.IsValid)
            {
                db.Universities.Add(university);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.City = new SelectList(db.Cities, "CityID", "CityEng", university.City);
            return View(university);
        }

        // GET: Universities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = await db.Universities.FindAsync(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            ViewBag.City = new SelectList(db.Cities, "CityID", "CityEng", university.City);
            return View(university);
        }

        // POST: Universities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "UniveristyID,UniversityEng,UniversityArb,AboutUniversityEng,AboutUniversityArb,City,Location,logo,CreatedDate,UniversityURL,GlobalRank,ContinetRank,RegionalRank,LocalRank")] University university)
        public async Task<ActionResult> Edit([Bind(Exclude = "logo")] University university, HttpPostedFileBase logo)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (logo == null || logo.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!validImageTypes.Contains(logo.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image");
            }

            byte[] data;
            using (Stream inputStream = logo.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            university.logo = data;
            if (ModelState.IsValid)
            {
                db.Entry(university).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.City = new SelectList(db.Cities, "CityID", "CityEng", university.City);
            return View(university);
        }

        // GET: Universities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            University university = await db.Universities.FindAsync(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // POST: Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            University university = await db.Universities.FindAsync(id);
            db.Universities.Remove(university);
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
