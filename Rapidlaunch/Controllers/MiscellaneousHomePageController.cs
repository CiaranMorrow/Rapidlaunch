using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Rapidlaunch.Controllers
{
    public class MiscellaneousHomePageController : Controller
    {
        // GET: MiscellaneousHomePage
        public ActionResult Index()
        {
            return View();
        }

        // GET: MiscellaneousHomePage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MiscellaneousHomePage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MiscellaneousHomePage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MiscellaneousHomePage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MiscellaneousHomePage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MiscellaneousHomePage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MiscellaneousHomePage/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}