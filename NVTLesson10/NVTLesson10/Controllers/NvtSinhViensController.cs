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
    public class NvtSinhViensController : Controller
    {
        private NVTK22CNT1Lesson10Entities db = new NVTK22CNT1Lesson10Entities();

        // GET: NvtSinhViens
        public ActionResult NvtIndex()
        {
            var nvtSinhViens = db.NvtSinhViens.Include(n => n.NvtKhoa);
            return View(nvtSinhViens.ToList());
        }

        // GET: NvtSinhViens/Details/5
        public ActionResult NvtDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtSinhVien nvtSinhVien = db.NvtSinhViens.Find(id);
            if (nvtSinhVien == null)
            {
                return HttpNotFound();
            }
            return View(nvtSinhVien);
        }

        // GET: NvtSinhViens/Create
        public ActionResult NvtCreate()
        {
            ViewBag.NvtMaKH = new SelectList(db.NvtKhoas, "NvtMaKH", "NvtTenKH");
            return View();
        }

        // POST: NvtSinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvtCreate([Bind(Include = "NvtMaSV,NvtHoSV,NvtTenSV,NvtPhai,NvtNgaySinh,NvtNoiSinh,NvtMaKH,NvtHocBong,NvtDiemTrungBinh")] NvtSinhVien nvtSinhVien)
        {
            if (ModelState.IsValid)
            {
                db.NvtSinhViens.Add(nvtSinhVien);
                db.SaveChanges();
                return RedirectToAction("NvtIndex");
            }

            ViewBag.NvtMaKH = new SelectList(db.NvtKhoas, "NvtMaKH", "NvtTenKH", nvtSinhVien.NvtMaKH);
            return View(nvtSinhVien);
        }

        // GET: NvtSinhViens/Edit/5
        public ActionResult NvtEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtSinhVien nvtSinhVien = db.NvtSinhViens.Find(id);
            if (nvtSinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.NvtMaKH = new SelectList(db.NvtKhoas, "NvtMaKH", "NvtTenKH", nvtSinhVien.NvtMaKH);
            return View(nvtSinhVien);
        }

        // POST: NvtSinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvtEdit([Bind(Include = "NvtMaSV,NvtHoSV,NvtTenSV,NvtPhai,NvtNgaySinh,NvtNoiSinh,NvtMaKH,NvtHocBong,NvtDiemTrungBinh")] NvtSinhVien nvtSinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nvtSinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NvtIndex");
            }
            ViewBag.NvtMaKH = new SelectList(db.NvtKhoas, "NvtMaKH", "NvtTenKH", nvtSinhVien.NvtMaKH);
            return View(nvtSinhVien);
        }

        // GET: NvtSinhViens/Delete/5
        public ActionResult NvtDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NvtSinhVien nvtSinhVien = db.NvtSinhViens.Find(id);
            if (nvtSinhVien == null)
            {
                return HttpNotFound();
            }
            return View(nvtSinhVien);
        }

        // POST: NvtSinhViens/Delete/5
        [HttpPost, ActionName("NvtDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult NvtDeleteConfirmed(string id)
        {
            NvtSinhVien nvtSinhVien = db.NvtSinhViens.Find(id);
            db.NvtSinhViens.Remove(nvtSinhVien);
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
