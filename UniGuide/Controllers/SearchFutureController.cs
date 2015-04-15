using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniGuide.Models;

namespace UniGuide.Controllers
{
    public class SearchFutureController : BaseController
    {
        private UniGuideEntities db = new UniGuideEntities();
        // GET: SearchFuture
        public ActionResult SearchFuture()
        {
            string lang = (string)this.RouteData.Values["culture"];
            ViewBag.Degree = new SelectList(db.Degrees, "DegreeID", "DegreeEng");
            if(lang.Equals("ar"))
            {
                ViewBag.Degree = new SelectList(db.Degrees, "DegreeID", "DegreeArb");
            }
            ViewBag.City = new SelectList(db.Cities, "CityID", "CityEng");
            if (lang.Equals("ar"))
            {
                ViewBag.City = new SelectList(db.Cities, "CityID", "CityArb");
            }
            ViewBag.AdmissionType = new SelectList(db.AdmissionTypes, "AdmisionID", "AdmisionEng");
            if (lang.Equals("ar"))
            {
                ViewBag.AdmissionType = new SelectList(db.AdmissionTypes, "AdmisionID", "AdmisionArb");
            }
            ViewBag.Categroy = new SelectList(db.Categories, "CatID", "CategoryEng");
            if (lang.Equals("ar"))
            {
                ViewBag.Categroy = new SelectList(db.Categories, "CatID", "CategoryArb");
            }            
            ViewBag.Dicipline = new SelectList(db.Diciplines, "DiciID", "DiciplineEng");
            if (lang.Equals("ar"))
            {
                ViewBag.Dicipline = new SelectList(db.Diciplines, "DiciID", "DiciplineArb");
            }
            List<SelectListItem> years = new List<SelectListItem>();
            years.Add(new SelectListItem { Selected = true, Text = "6", Value = "6" });
            years.Add(new SelectListItem { Text = "5", Value = "5" });
            years.Add(new SelectListItem { Text = "4", Value = "4" });
            years.Add(new SelectListItem { Text = "3", Value = "3" });
            years.Add(new SelectListItem { Text = "2", Value = "2" });
            years.Add(new SelectListItem { Text = "1", Value = "1" });

            ViewBag.Years = years;

            return View();
        }
    }
}