using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grid_and_CRUD.Data;
using Grid_and_CRUD.Models;
using Grid_and_CRUD.Classes;
using Grid_and_CRUD.Data.Southwind;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Grid_and_CRUD.Controllers
{
    public class FullSummaryController : Controller
    {
        public Data.Southwind.SouthwindEntities southwind = new Data.Southwind.SouthwindEntities();
        // GET: FullSummary
        public ActionResult FullSummary()
        {
            return PartialView("FullSummary");
        }

        // Dropdown Lists/Tree
        public JsonResult SocietyDDL()
        {
            var society = new List<SelectListItem>
                {
                    new SelectListItem { Text = "All"},
                    new SelectListItem { Text = "Satcher" },
                    new SelectListItem { Text = "Robbins" },
                    new SelectListItem { Text = "Wearn" },
                    new SelectListItem { Text = "Blackwell" },
                    new SelectListItem { Text = "Geiger" },
                    new SelectListItem { Text = "Gerberding" }
                };
            ViewData["society"] = society;
            return Json(society, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GyrDDL()
        {
            var classYear = southwind.vw_Matri_Grad_Dates
                .Where(c => c.campuscode == "cwru")
                .Where(c => c.Prog_status == "AC" || c.Prog_status=="LA")
                .GroupBy(c => c.gyr)
                .Select(c => c.FirstOrDefault())
                .Select(c => new { classYear = c.gyr })
                .Distinct()
                .Take(6)
                .OrderByDescending(c => c.classYear)
                .ToList();
            classYear.Add(new { classYear = "LOA" });
            classYear.Add(new { classYear = "PHD" });
            ViewData["classYear"] = classYear;
            return Json(classYear, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStudentsDDL(string classYear, string society)
        {
            if (Session["classYear"] != null)
                classYear = Session["classYear"].ToString();

            if (Session["society"] != null)
                society = Session["society"].ToString();


            if (society == "All")
            {
                var allByYear = southwind.v_studentsAll
                    .Where(x => x.gyr == classYear)
                    .Where(x => x.Prog_status == "AC")
                    .OrderBy(x => x.Emplid)
                    .Select(x => x.Emplid)
                    .ToList();

                var allInYear = allByYear
                    .Select(c => Int32.Parse(c))
                    .ToList();



                var loaByYear = southwind.v_studentsAll
                    .Where(c => c.campuscode == "cwru")
                    .Where(c => c.Prog_status == "LA" || (c.Prog_status == "AC" && c.reduced_fee == "y"))
                    .OrderBy(c => c.Emplid)
                    .Select(c => c.Emplid)
                    .ToList();

                var loaInYear = loaByYear
                    .Select(c => Int32.Parse(c))
                    .ToList();

                var allPersonalInfo = southwind.v_studentsAll
                    .Where(x => allByYear.Contains(x.Emplid) || loaByYear.Contains(x.Emplid))
                    .OrderBy(x => x.Last_Name)
                    .Select(x => new { Name = x.studentname, Value = x.emaddr.Trim() })
                    .ToList();

                return Json(allPersonalInfo, JsonRequestBehavior.AllowGet);
            }

            if (classYear == "LOA" || classYear == "PHD")
            {
                var loaByYear = southwind.v_studentsAll
                    .Where(c => c.campuscode == "cwru")
                    .Where(c => c.Prog_status == "LA" || (c.Prog_status == "AC" && c.reduced_fee == "y"))
                    .OrderBy(c => c.Emplid)
                    .Select(c => c.Emplid)
                    .ToList();

                var loaInYear = loaByYear
                    .Select(c => Int32.Parse(c))
                    .ToList();

                var loaBySociety = southwind.v_StudentsSOM
                    .Where(x => x.advisor_society.Contains(society))
                    .Where(x => loaByYear.Contains(x.Emplid))
                    .Select(x => x.Emplid)
                    .ToList();

                var loaInSociety = loaBySociety
                    .Select(c => Int32.Parse(c))
                    .ToList();

                var loaPersonalInfo = southwind.v_studentsAll
                    .Where(x => loaBySociety.Contains(x.Emplid) && (loaByYear.Contains(x.Emplid)))
                    .OrderBy(x => x.Last_Name)
                    .Select(x => new { Name = x.studentname, Value = x.emaddr.Trim() })
                    .ToList();

                return Json(loaPersonalInfo, JsonRequestBehavior.AllowGet);


            }

            var gradsByYear = southwind.v_StudentsSOM
                   .Where(x => x.gyr == classYear)
                   .Where(x => x.advisor_society.Contains(society))
                   .Where(x => x.Prog_status == "AC")
                   .OrderBy(x => x.Emplid)
                   .Select(x => x.Emplid)
                   .ToList();

            var gradsInYear = gradsByYear
                .Select(x => Int32.Parse(x))
                .ToList();

            var personalInfo = southwind.v_studentsAll
                .Where(x => gradsByYear.Contains(x.Emplid))
                .OrderBy(x => x.Last_Name)
                .Select(x => new { Name = x.studentname, Value = x.emaddr.Trim() })
                .ToList();

            return Json(personalInfo, JsonRequestBehavior.AllowGet);
        }

        // Student Details 

        // Student Grades

        // Type A & B Electives

        // Dean Notes
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Notes_Create([DataSourceRequest] DataSourceRequest request, FullSummary.AdvisoryNotesViewModel advisoryNote)
        {
            if (ModelState.IsValid)
            {
                using (var sw = new SouthwindEntities())
                {                   
                    var entity = new AdvisoryNote
                    {
                        nid = advisoryNote.nid,
                        emaddr = UserSession.Student,
                        edate = advisoryNote.edate,
                        etitle = advisoryNote.etitle,
                        enotes = advisoryNote.enotes,
                        adlogin = advisoryNote.adlogin,
                        notefile = advisoryNote.notefile
                    };
                    sw.AdvisoryNotes.Add(entity);
                    sw.SaveChanges();
                    advisoryNote.nid = entity.nid;
                   
                }
            }
            return Json(new[] { advisoryNote }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Notes_Read([DataSourceRequest] DataSourceRequest request, string emaddr)
        {
            emaddr = UserSession.Student;
            var result = southwind.AdvisoryNotes.Select(n => new FullSummary.AdvisoryNotesViewModel()
            {
                adlogin = n.adlogin.Trim(),
                edate = n.edate,
                emaddr = n.emaddr.Trim(),
                enotes = n.enotes,
                etitle = n.etitle,
                nid = n.nid,
                notefile = n.notefile
            }).Where(n=>n.emaddr == emaddr).OrderByDescending(n => n.edate);

            return Json(result.ToDataSourceResult(request));
        }        

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Notes_Update([DataSourceRequest] DataSourceRequest request, FullSummary.AdvisoryNotesViewModel advisoryNote)
        {
            if (ModelState.IsValid)
            {
                using (var sw = new SouthwindEntities())
                {
                    var entity = new AdvisoryNote
                    {
                        nid = advisoryNote.nid,
                        emaddr = UserSession.Student,
                        edate = advisoryNote.edate,
                        etitle = advisoryNote.etitle,
                        enotes = advisoryNote.enotes, 
                        adlogin = advisoryNote.adlogin,
                        notefile = advisoryNote.notefile
                    };
                    sw.AdvisoryNotes.Attach(entity);
                    sw.Entry(entity).State = EntityState.Modified;
                    sw.SaveChanges();
                }
            }
            return Json(new[] {advisoryNote}.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Notes_Destroy([DataSourceRequest] DataSourceRequest request, FullSummary.AdvisoryNotesViewModel advisoryNote)
        {
            if (ModelState.IsValid)
            {
                using (var sw = new SouthwindEntities())
                {
                    var entity = new AdvisoryNote
                    {
                        nid = advisoryNote.nid,
                        emaddr = UserSession.Student,
                        edate = advisoryNote.edate,
                        etitle = advisoryNote.etitle,
                        enotes = advisoryNote.enotes, 
                        adlogin = advisoryNote.adlogin,
                        notefile = advisoryNote.notefile
                    };
                    sw.AdvisoryNotes.Attach(entity);
                    sw.AdvisoryNotes.Remove(entity);
                    sw.SaveChanges();
                }
            }
            return Json(new[] {advisoryNote}.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
        
        // Saved Inputs
        public string SaveGradYear(string classYear)
        {
            Session["classYear"] = classYear;

            return classYear;
        }

        public string SaveSociety(string society)
        {
            Session["society"] = society;

            return society;
        }

        public string SaveReport(string report)
        {
            Session["report"] = report;

            return report;
        }

        [HttpPost]
        public ActionResult SelectedSociety(string society)
        {
            UserSession.Society = society;
            return Json(new { success = true });
        }
        
        [HttpPost]
        public ActionResult SelectedGyr(string classYear)
        {
            UserSession.GradYear = classYear;
            return Json(new { success = true });
        }
        
        [HttpPost]
        public ActionResult SelectedReport(string report)
        {
            UserSession.Report = report;
            return Json(new { success = true });
        }
        
        [HttpPost]
        public ActionResult SelectedStudent(string student)
        {
            UserSession.Student = student;
            return Json(new { success = true });
        }
        
        // Partial View

        public PartialViewResult DeanNotesPartialView()
        {
            return PartialView("_AdvisoryNotesGrid");
        }




    }
}