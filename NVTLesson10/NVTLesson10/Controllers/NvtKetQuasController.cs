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
    public class NvtKetQuasController : Controller
    {
        private NVTK22CNT1Lesson10Entities db = new NVTK22CNT1Lesson10Entities();

        // GET: NvtKetQuas
        public ActionResult NvtIndex()
        {
            var nvtKetQuas = db.NvtKetQuas.Include(n => n.NvtMonHoc).Include(n => n.NvtSinhVien);
            return View(nvtKetQuas.ToList());
        }

        // GET: NvtKetQuas/Details/5
        public ActionResult NvtDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtKetQua nvtKetQua = db.NvtKetQuas.Find(id);
            if (nvtKetQua == null)
            {
                return HttpNotFound();
            }
            return View(nvtKetQua);
        }

        // GET: NvtKetQuas/Create
        public ActionResult NvtCreate()
        {
            ViewBag.NvtMaMH = new SelectList(db.NvtMonHocs, "NvtMaMH", "NvtTenMH");
            ViewBag.NvtMaSV = new SelectList(db.NvtSinhViens, "NvtMaSV", "NvtHoSV");
            return View();
        }

        // POST: NvtKetQuas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvtCreate([Bind(Include = "NvtMaSV,NvtMaMH,NvtDiem")] NvtKetQua nvtKetQua)
        {
            if (ModelState.IsValid)
            {
                db.NvtKetQuas.Add(nvtKetQua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NvtMaMH = new SelectList(db.NvtMonHocs, "NvtMaMH", "NvtTenMH", nvtKetQua.NvtMaMH);
            ViewBag.NvtMaSV = new SelectList(db.NvtSinhViens, "NvtMaSV", "NvtHoSV", nvtKetQua.NvtMaSV);
            return View(nvtKetQua);
        }

        // GET: NvtKetQuas/Edit/5
        public ActionResult NvtEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtKetQua nvtKetQua = db.NvtKetQuas.Find(id);
            if (nvtKetQua == null)
            {
                return HttpNotFound();
            }
            ViewBag.NvtMaMH = new SelectList(db.NvtMonHocs, "NvtMaMH", "NvtTenMH", nvtKetQua.NvtMaMH);
            ViewBag.NvtMaSV = new SelectList(db.NvtSinhViens, "NvtMaSV", "NvtHoSV", nvtKetQua.NvtMaSV);
            return View(nvtKetQua);
        }

        // POST: NvtKetQuas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvtEdit([Bind(Include = "NvtMaSV,NvtMaMH,NvtDiem")] NvtKetQua nvtKetQua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nvtKetQua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NvtIndex");
            }
            ViewBag.NvtMaMH = new SelectList(db.NvtMonHocs, "NvtMaMH", "NvtTenMH", nvtKetQua.NvtMaMH);
            ViewBag.NvtMaSV = new SelectList(db.NvtSinhViens, "NvtMaSV", "NvtHoSV", nvtKetQua.NvtMaSV);
            return View(nvtKetQua);
        }

        // GET: NvtKetQuas/Delete/5
        public ActionResult NvtDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtKetQua nvtKetQua = db.NvtKetQuas.Find(id);
            if (nvtKetQua == null)
            {
                return HttpNotFound();
            }
            return View(nvtKetQua);
        }

        // POST: NvtKetQuas/Delete/5
        [HttpPost, ActionName("NvtDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult NvtDeleteConfirmed(string id)
        {
            NvtKetQua nvtKetQua = db.NvtKetQuas.Find(id);
            db.NvtKetQuas.Remove(nvtKetQua);
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
