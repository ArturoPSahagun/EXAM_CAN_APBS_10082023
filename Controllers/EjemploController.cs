using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace surtidora_api.Controllers
{
    public class EjemploController : Controller
    {
        // GET: Ejemplo
        public string Index()
        {
            return "HOLAS";
        }

        // GET: Ejemplo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ejemplo/Create
        public string Create()
        {
            return "adiossss";
        }

        // POST: Ejemplo/Create
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

        // GET: Ejemplo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ejemplo/Edit/5
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

        // GET: Ejemplo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ejemplo/Delete/5
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
