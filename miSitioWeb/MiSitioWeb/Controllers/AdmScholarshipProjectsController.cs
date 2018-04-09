namespace MiSitioWeb.Controllers
{
    using Comun.Tool;
    using Data.Models.Crud;
    using MiSitioWeb.Data.Models.Tables;
    using System.Web.Mvc;

    public class AdmScholarshipProjectsController : Controller
    {
        // GET: AdmScholarshipProjects
        public ActionResult Index(int EducationId)
        {
            string GetDataIndex = "/AdmScholarshipProjects/GetDataIndex?EducationId=" + EducationId;
            string LocationCreate = "/AdmScholarshipProjects/Create?EducationId=" + EducationId;
            string LocationEdit = "/AdmScholarshipProjects/Edit?ProjectId=";
            string LocationDelete = "/AdmScholarshipProjects/Delete?ProjectId=";

            ViewBag.GetDataIndex = GetDataIndex;
            ViewBag.LocationCreate = LocationCreate;
            ViewBag.LocationEdit = LocationEdit;
            ViewBag.LocationDelete = LocationDelete;
            ViewBag.EducationId = EducationId;

            return View();
        }

        [HttpGet]
        public JsonResult GetDataIndex(int EducationId)
        {
            var eLevels = DTScholarshipProject.GetList(EducationId);
            return Json(eLevels, JsonRequestBehavior.AllowGet);
        }

        // GET: AdmScholarshipProjects/Create
        public ActionResult Create(int EducationId)
        {
            ViewBag.EducationId = EducationId;
            return View();
        }

        // POST: Educations/Create
        [HttpPost]
        public JsonResult Create(ScholarshipProject model)
        {
            return Json(DTScholarshipProject.Create(model));
        }

        // GET: Educations/Edit/5
        public ActionResult Edit(int ProjectId)
        {
            ViewBag.ProjectId = ProjectId;
            return View();
        }

        [HttpGet]
        public JsonResult GetEditScholarshipProject(int ProjectId)
        {
            ScholarshipProject find = DTScholarshipProject.Find(ProjectId).To<ScholarshipProject>();
            return Json(find, JsonRequestBehavior.AllowGet);
        }

        // POST: Educations/Edit/5
        [HttpPost]
        public ActionResult Edit(ScholarshipProject model)
        {
            return Json(DTScholarshipProject.Create(model));
        }

        // POST: Educations/Delete/5
        [HttpGet]
        public JsonResult Delete(int ProjectId)
        {
            return Json(DTScholarshipProject.Delete(ProjectId), JsonRequestBehavior.AllowGet);
        }
    }
}
