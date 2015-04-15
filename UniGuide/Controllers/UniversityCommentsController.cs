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
    public class UniversityCommentsController : BaseController
    {
        private const int pageSize = 1;
        private UniGuideEntities db = new UniGuideEntities();

        // GET: UniversityComments
        //public ActionResult _UniversityComments(int id, int? entryCount)
        //{
        //    if (!entryCount.HasValue)
        //        entryCount = 1;

        //    int skipRows = (entryCount.Value - 1) * pageSize;

        //    if (Request.IsAjaxRequest())
        //    {
        //        var uniComments = (from UC in db.UniversityComments
        //                           orderby UC.Created ascending
        //                           select UC).Skip(skipRows).Take(pageSize).ToList();

        //        if (uniComments.Count() > 0)
        //        {
        //            AddMoreUrlToViewData(entryCount.Value);
        //        }
        //        return PartialView("_UniversityComments", uniComments);
        //    }

        //    var Comments = (from UC in db.UniversityComments
        //                       orderby UC.Created ascending
        //                       select UC).Skip(skipRows).Take(pageSize).ToList();

        //    if (Comments.Count() > 0)
        //    {
        //        AddMoreUrlToViewData(entryCount.Value);
        //    }
        //    return View(Comments);

        //    //var universityComments = db.UniversityComments.Include(u => u.University).Where(cu => cu.UniveristyID == id);
        //    //return PartialView(await universityComments.ToListAsync());
        //}

        private void AddMoreUrlToViewData(int entryCount)
        {
            ViewData["moreComment"] = Url.Action("_UniversityComments", "UniversityComments", new { entryCount = entryCount + pageSize });
            ViewBag.moreComment = Url.Action("_UniversityComments", "UniversityComments", new { entryCount = entryCount + pageSize });
        }

        // GET: UniversityComments/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityComment universityComment = await db.UniversityComments.FindAsync(id);
            if (universityComment == null)
            {
                return HttpNotFound();
            }
            return View(universityComment);
        }

        // GET: UniversityComments/Create
        public ActionResult Create()
        {
            ViewBag.UniveristyID = new SelectList(db.Universities, "UniveristyID", "UniversityEng");
            return View();
        }

        // POST: UniversityComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CommentID,UniveristyID,Comment,userID,Created")] UniversityComment universityComment)
        {
            if (ModelState.IsValid)
            {
                db.UniversityComments.Add(universityComment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UniveristyID = new SelectList(db.Universities, "UniveristyID", "UniversityEng", universityComment.UniveristyID);
            return View(universityComment);
        }

        // GET: UniversityComments/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityComment universityComment = await db.UniversityComments.FindAsync(id);
            if (universityComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.UniveristyID = new SelectList(db.Universities, "UniveristyID", "UniversityEng", universityComment.UniveristyID);
            return View(universityComment);
        }

        // POST: UniversityComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CommentID,UniveristyID,Comment,userID,Created")] UniversityComment universityComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universityComment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UniveristyID = new SelectList(db.Universities, "UniveristyID", "UniversityEng", universityComment.UniveristyID);
            return View(universityComment);
        }

        // GET: UniversityComments/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityComment universityComment = await db.UniversityComments.FindAsync(id);
            if (universityComment == null)
            {
                return HttpNotFound();
            }
            return View(universityComment);
        }

        // POST: UniversityComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            UniversityComment universityComment = await db.UniversityComments.FindAsync(id);
            db.UniversityComments.Remove(universityComment);
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
