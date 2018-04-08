namespace MiSitioWeb.Controllers
{
    using Data.Models.Crud;
    using Data.Models.Tables;
    using System.Web.Mvc;

    public class SocialNetworksController : Controller
    {
        public ActionResult Index()
        {
            string GetDataIndex = "/SocialNetworks/GetDataIndex";
            string LocationCreate = "/SocialNetworks/Create";
            string LocationEdit = "/SocialNetworks/Edit?SocialNetworkId=";
            string LocationDelete = "/SocialNetworks/Delete?SocialNetworkId=";

            ViewBag.GetDataIndex = GetDataIndex;
            ViewBag.LocationCreate = LocationCreate;
            ViewBag.LocationEdit = LocationEdit;
            ViewBag.LocationDelete = LocationDelete;

            return View();
        }

        [HttpGet]
        public JsonResult GetDataIndex()
        {
            var eLevels = DTSocialNetwork.GetList();
            return Json(eLevels, JsonRequestBehavior.AllowGet);
        }

        // GET: SocialNetworks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialNetworks/Create
        [HttpPost]
        public JsonResult Create(SocialNetwork model)
        {
            return Json(DTSocialNetwork.Create(model));
        }

        // GET: SocialNetworks/Edit/5
        public ActionResult Edit(int SocialNetworkId)
        {
            ViewBag.SocialId = SocialNetworkId;
            return View();
        }

        [HttpGet]
        public JsonResult GetEditSocialNetwork(int SocialId)
        {
            SocialNetwork SocialNetwork = DTSocialNetwork.Find(SocialId);
            return Json(SocialNetwork, JsonRequestBehavior.AllowGet);
        }

        // POST: SocialNetworks/Edit/5
        [HttpPost]
        public ActionResult Edit(SocialNetwork model)
        {
            return Json(DTSocialNetwork.Create(model));
        }

        // POST: SocialNetworks/Delete/5
        [HttpGet]
        public JsonResult Delete(int SocialNetworkId)
        {
            return Json(DTSocialNetwork.Delete(SocialNetworkId), JsonRequestBehavior.AllowGet);
        }
    }
}
