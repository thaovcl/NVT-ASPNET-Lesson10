using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NVTLesson10.Models;

namespace NVTLesson10.Controllers
{
    public class NvtKhoasController : Controller
    {
        private NVTK22CNT1Lesson10Entities db = new NVTK22CNT1Lesson10Entities();

        // GET: NvtKhoas
        public ActionResult NvtIndex()
        {
            return View(db.NvtKhoas.ToList());
        }

        // GET: NvtKhoas/Details/5
        public ActionResult NvtDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtKhoa nvtKhoa = db.NvtKhoas.Find(id);
            if (nvtKhoa == null)
            {
                return HttpNotFound();
            }
            return View(nvtKhoa);
        }

        // GET: NvtKhoas/Create
        public ActionResult NvtCreate()
        {
            return View();
        }

        // POST: NvtKhoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvtCreate([Bind(Include = "NvtMaKH,NvtTenKH")] NvtKhoa nvtKhoa)
        {
            if (ModelState.IsValid)
            {
                db.NvtKhoas.Add(nvtKhoa);
                db.SaveChanges();
                return RedirectToAction("NvtIndex");
            }

            return View(nvtKhoa);
        }

        // GET: NvtKhoas/Edit/5
        public ActionResult NvtEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtKhoa nvtKhoa = db.NvtKhoas.Find(id);
            if (nvtKhoa == null)
            {
                return HttpNotFound();
            }
            return View(nvtKhoa);
        }

        // POST: NvtKhoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvtEdit([Bind(Include = "NvtMaKH,NvtTenKH")] NvtKhoa nvtKhoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nvtKhoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NvtIndex");
            }
            return View(nvtKhoa);
        }

        // GET: NvtKhoas/Delete/5
        public ActionResult NvtDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtKhoa nvtKhoa = db.NvtKhoas.Find(id);
            if (nvtKhoa == null)
            {
                return HttpNotFound();
            }
            return View(nvtKhoa);
        }

        // POST: NvtKhoas/Delete/5
        [HttpPost, ActionName("NvtDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult NvtDeleteConfirmed(string id)
        {
            NvtKhoa nvtKhoa = db.NvtKhoas.Find(id);
            db.NvtKhoas.Remove(nvtKhoa);
            db.SaveChanges();
            return RedirectToAction("NvtIndex");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
