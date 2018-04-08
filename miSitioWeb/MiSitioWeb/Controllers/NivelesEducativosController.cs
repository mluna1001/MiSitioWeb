namespace MiSitioWeb.Controllers
{
    using Data.Models.Crud;
    using Data.Models.Tables;
    using System.Web.Mvc;

    public class NivelesEducativosController : Controller
    {
        // GET: NivelesEducativos
        public ActionResult Index()
        {
            string GetDataIndex = "/NivelesEducativos/GetDataIndex";
            string LocationCreate = "/NivelesEducativos/Create";
            string LocationEdit = "/NivelesEducativos/Edit?EducationLevelId=";
            string LocationDelete = "/NivelesEducativos/Delete?EducationLevelId=";

            ViewBag.GetDataIndex = GetDataIndex;
            ViewBag.LocationCreate = LocationCreate;
            ViewBag.LocationEdit = LocationEdit;
            ViewBag.LocationDelete = LocationDelete;

            return View();
        }

        [HttpGet]
        public JsonResult GetDataIndex()
        {
            var eLevels = DTEducationLevel.GetList();
            return Json(eLevels, JsonRequestBehavior.AllowGet);
        }

        // GET: NivelesEducativos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NivelesEducativos/Create
        [HttpPost]
        public JsonResult Create(EducationLevel model)
        {
            return Json(DTEducationLevel.Create(model));
        }

        // GET: NivelesEducativos/Edit/5
        public ActionResult Edit(int EducationLevelId)
        {
            ViewBag.EducationLevelId = EducationLevelId;
            return View();
        }

        [HttpGet]
        public JsonResult GetEditEducationLevel(int EducationLevelId)
        {
            EducationLevel educationLevel = DTEducationLevel.Find(EducationLevelId);
            return Json(educationLevel, JsonRequestBehavior.AllowGet);
        }

        // POST: NivelesEducativos/Edit/5
        [HttpPost]
        public ActionResult Edit(EducationLevel model)
        {
            return Json(DTEducationLevel.Create(model));
        }

        // POST: NivelesEducativos/Delete/5
        [HttpGet]
        public JsonResult Delete(int EducationLevelId)
        {
            return Json(DTEducationLevel.Delete(EducationLevelId), JsonRequestBehavior.AllowGet);
        }
    }
}
