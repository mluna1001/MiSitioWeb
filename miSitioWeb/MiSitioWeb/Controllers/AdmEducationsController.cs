namespace MiSitioWeb.Controllers
{
    using Data.Models.Crud;
    using Data.Models.Tables;
    using Data.Models.DTO;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Comun.Tool;

    public class AdmEducationsController : Controller
    {
        // GET: Educations
        public ActionResult Index()
        {
            string GetDataIndex = "/AdmEducations/GetDataIndex";
            string LocationCreate = "/AdmEducations/Create";
            string LocationEdit = "/AdmEducations/Edit?EducationId=";
            string LocationDelete = "/AdmEducations/Delete?EducationId=";
            string SelectLocation = "/AdmScholarshipProjects?EducationId=";

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
            var eLevels = DTEducation.GetList();
            return Json(eLevels, JsonRequestBehavior.AllowGet);
        }

        // GET: Educations/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetDataEducationLevel()
        {
            List<EducationLevel> educationLevelList = DTEducationLevel.GetList();
            return Json(educationLevelList, JsonRequestBehavior.AllowGet);
        }

        // POST: Educations/Create
        [HttpPost]
        public JsonResult Create(Education model)
        {
            //User user = new User()
            //{
            //    LastName = "Luna",
            //    MiddleName = "Serrano",
            //    FirstName = "Marco Antonio",
            //    BirthDate = new System.DateTime(1992, 5, 3),
            //    UserName = "donverga",
            //    RealPassword = "123456",
            //    Email = "correo@cosmic.mx"
            //};

            //DTUser.CreateUser(user);
            model.UserId = 1;
            return Json(DTEducation.Create(model));
        }

        // GET: Educations/Edit/5
        public ActionResult Edit(int EducationId)
        {
            ViewBag.EducationId = EducationId;
            return View();
        }

        [HttpGet]
        public JsonResult GetEditEducation(int EducationId)
        {
            Education find = DTEducation.Find(EducationId).To<Education>();
            return Json(find, JsonRequestBehavior.AllowGet);
        }

        // POST: Educations/Edit/5
        [HttpPost]
        public ActionResult Edit(Education model)
        {
            return Json(DTEducation.Create(model));
        }

        // POST: Educations/Delete/5
        [HttpGet]
        public JsonResult Delete(int EducationId)
        {
            return Json(DTEducation.Delete(EducationId), JsonRequestBehavior.AllowGet);
        }
    }
}
