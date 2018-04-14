namespace MiSitioWeb.Controllers
{
    using Comun.Tool;
    using Data.Models.Crud;
    using Data.Models.Tables;
    using System.Web.Mvc;

    public class AdmWorkProjectsController : Controller
    {
        // GET: AdmWorkProjects
        public ActionResult Index(int WorkExperienceId)
        {
            string GetDataIndex = "/AdmWorkProjects/GetDataIndex?WorkExperienceId=" + WorkExperienceId;
            string LocationCreate = "/AdmWorkProjects/Create?WorkExperienceId=" + WorkExperienceId;
            string LocationEdit = "/AdmWorkProjects/Edit?WorkProjectId=";
            string LocationDelete = "/AdmWorkProjects/Delete?WorkProjectId=";

            ViewBag.GetDataIndex = GetDataIndex;
            ViewBag.LocationCreate = LocationCreate;
            ViewBag.LocationEdit = LocationEdit;
            ViewBag.LocationDelete = LocationDelete;
            ViewBag.WorkExperienceId = WorkExperienceId;

            return View();
        }

        [HttpGet]
        public JsonResult GetDataIndex(int WorkExperienceId)
        {
            var eLevels = DTWorkProject.GetList(WorkExperienceId);
            return Json(eLevels, JsonRequestBehavior.AllowGet);
        }

        // GET: AdmWorkProjects/Create
        public ActionResult Create(int WorkExperienceId)
        {
            ViewBag.WorkExperienceId = WorkExperienceId;
            return View();
        }

        // POST: Educations/Create
        [HttpPost]
        public JsonResult Create(WorkProject model)
        {
            return Json(DTWorkProject.Create(model));
        }

        // GET: Educations/Edit/5
        public ActionResult Edit(int WorkProjectId)
        {
            ViewBag.WorkProjectId = WorkProjectId;
            return View();
        }

        [HttpGet]
        public JsonResult GetEditWorkProject(int WorkProjectId)
        {
            WorkProject find = DTWorkProject.Find(WorkProjectId).To<WorkProject>();
            return Json(find, JsonRequestBehavior.AllowGet);
        }

        // POST: Educations/Edit/5
        [HttpPost]
        public ActionResult Edit(WorkProject model)
        {
            return Json(DTWorkProject.Create(model));
        }

        // POST: Educations/Delete/5
        [HttpGet]
        public JsonResult Delete(int WorkProjectId)
        {
            return Json(DTWorkProject.Delete(WorkProjectId), JsonRequestBehavior.AllowGet);
        }
    }
}
