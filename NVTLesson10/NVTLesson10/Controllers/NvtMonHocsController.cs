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
    public class NvtMonHocsController : Controller
    {
        private NVTK22CNT1Lesson10Entities db = new NVTK22CNT1Lesson10Entities();

        // GET: NvtMonHocs
        public ActionResult NvtIndex()
        {
            return View(db.NvtMonHocs.ToList());
        }

        // GET: NvtMonHocs/Details/5
        public ActionResult NvtDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtMonHoc nvtMonHoc = db.NvtMonHocs.Find(id);
            if (nvtMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(nvtMonHoc);
        }

        // GET: NvtMonHocs/Create
        public ActionResult NvtCreate()
        {
            return View();
        }

        // POST: NvtMonHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvtCreate([Bind(Include = "NvtMaMH,NvtTenMH,NvtSoTiet")] NvtMonHoc nvtMonHoc)
        {
            if (ModelState.IsValid)
            {
                db.NvtMonHocs.Add(nvtMonHoc);
                db.SaveChanges();
                return RedirectToAction("NvtIndex");
            }

            return View(nvtMonHoc);
        }

        // GET: NvtMonHocs/Edit/5
        public ActionResult NvtEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtMonHoc nvtMonHoc = db.NvtMonHocs.Find(id);
            if (nvtMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(nvtMonHoc);
        }

        // POST: NvtMonHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvtEdit([Bind(Include = "NvtMaMH,NvtTenMH,NvtSoTiet")] NvtMonHoc nvtMonHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nvtMonHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NvtIndex");
            }
            return View(nvtMonHoc);
        }

        // GET: NvtMonHocs/Delete/5
        public ActionResult NvtDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtMonHoc nvtMonHoc = db.NvtMonHocs.Find(id);
            if (nvtMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(nvtMonHoc);
        }

        // POST: NvtMonHocs/Delete/5
        [HttpPost, ActionName("NvtDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NvtMonHoc nvtMonHoc = db.NvtMonHocs.Find(id);
            db.NvtMonHocs.Remove(nvtMonHoc);
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
