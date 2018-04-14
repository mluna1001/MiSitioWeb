namespace MiSitioWeb.Controllers
{
    using Comun.Tool;
    using Data.Models.Crud;
    using Data.Models.Tables;
    using System.Web.Mvc;

    public class AdmWorksController : Controller
    {
        // GET: Works
        public ActionResult Index()
        {
            string GetDataIndex = "/AdmWorks/GetDataIndex";
            string LocationCreate = "/AdmWorks/Create";
            string LocationEdit = "/AdmWorks/Edit?WorkExperienceId=";
            string LocationDelete = "/AdmWorks/Delete?WorkExperienceId=";
            string SelectLocation = "/AdmWorkProjects?WorkExperienceId=";

            ViewBag.GetDataIndex = GetDataIndex;
            ViewBag.LocationCreate = LocationCreate;
            ViewBag.LocationEdit = LocationEdit;
            ViewBag.LocationDelete = LocationDelete;
            ViewBag.SelectLocation = SelectLocation;

            return View();
        }

        [HttpGet]
        public JsonResult GetDataIndex()
        {
            var eLevels = DTWorkExperience.GetList();
            return Json(eLevels, JsonRequestBehavior.AllowGet);
        }

        // GET: Works/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Works/Create
        [HttpPost]
        public JsonResult Create(WorkExperience model)
        {
            model.UserId = 1;
            return Json(DTWorkExperience.Create(model));
        }

        // GET: Works/Edit/5
        public ActionResult Edit(int WorkExperienceId)
        {
            ViewBag.WorkExperienceId = WorkExperienceId;
            return View();
        }

        [HttpGet]
        public JsonResult GetEditWork(int WorkExperienceId)
        {
            WorkExperience find = DTWorkExperience.Find(WorkExperienceId).To<WorkExperience>();
            return Json(find, JsonRequestBehavior.AllowGet);
        }

        // POST: Works/Edit/5
        [HttpPost]
        public ActionResult Edit(WorkExperience model)
        {
            return Json(DTWorkExperience.Create(model));
        }

        // POST: Works/Delete/5
        [HttpGet]
        public JsonResult Delete(int WorkId)
        {
            return Json(DTWorkExperience.Delete(WorkId), JsonRequestBehavior.AllowGet);
        }
    }
}
