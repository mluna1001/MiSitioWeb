using MiSitioWeb.Data.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiSitioWeb.Controllers
{
    public class NivelesEducativosController : Controller
    {
        // GET: NivelesEducativos
        public ActionResult Index()
        {
            string GetDataIndex = "/NivelesEducativos/GetDataIndex";
            string LocationCreate = "/NivelesEducativos/Create";

            ViewBag.GetDataIndex = GetDataIndex;
            ViewBag.LocationCreate = LocationCreate;
            return View();
        }

        [HttpGet]
        public JsonResult GetDataIndex()
        {
            var eLevels = DTEducationLevel.GetEducationLevels();
            return Json(eLevels, JsonRequestBehavior.AllowGet);
        }

        // GET: NivelesEducativos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NivelesEducativos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NivelesEducativos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NivelesEducativos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NivelesEducativos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NivelesEducativos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NivelesEducativos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
