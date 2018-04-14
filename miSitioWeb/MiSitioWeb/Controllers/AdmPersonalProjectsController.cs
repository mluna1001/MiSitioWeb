namespace MiSitioWeb.Controllers
{
    using Comun.Tool;
    using Data.Models.Crud;
    using Data.Models.Tables;
    using System.Web.Mvc;

    public class AdmPersonalProjectsController : Controller
    {
        // GET: AdmPersonalProjects
        public ActionResult Index()
        {
            string GetDataIndex = "/AdmPersonalProjects/GetDataIndex";
            string LocationCreate = "/AdmPersonalProjects/Create";
            string LocationEdit = "/AdmPersonalProjects/Edit?PersonalProjectId=";
            string LocationDelete = "/AdmPersonalProjects/Delete?PersonalProjectId=";

            ViewBag.GetDataIndex = GetDataIndex;
            ViewBag.LocationCreate = LocationCreate;
            ViewBag.LocationEdit = LocationEdit;
            ViewBag.LocationDelete = LocationDelete;

            return View();
        }

        [HttpGet]
        public JsonResult GetDataIndex()
        {
            var eLevels = DTPersonalProject.GetList();
            return Json(eLevels, JsonRequestBehavior.AllowGet);
        }

        // GET: AdmPersonalProjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmPersonalProjects/Create
        [HttpPost]
        public JsonResult Create(PersonalProject model)
        {
            model.UserId = 1;
            return Json(DTPersonalProject.Create(model));
        }

        // GET: AdmPersonalProjects/Edit/5
        public ActionResult Edit(int PersonalProjectId)
        {
            ViewBag.PersonalProjectId = PersonalProjectId;
            return View();
        }

        [HttpGet]
        public JsonResult GetEditPersonalProject(int PersonalProjectId)
        {
            PersonalProject find = DTPersonalProject.Find(PersonalProjectId).To<PersonalProject>();
            return Json(find, JsonRequestBehavior.AllowGet);
        }

        // POST: AdmPersonalProjects/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonalProject model)
        {
            return Json(DTPersonalProject.Create(model));
        }

        // POST: AdmPersonalProjects/Delete/5
        [HttpGet]
        public JsonResult Delete(int PersonalProjectId)
        {
            return Json(DTPersonalProject.Delete(PersonalProjectId), JsonRequestBehavior.AllowGet);
        }
    }
}
