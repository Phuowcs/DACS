using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testDACS.Models;

namespace testDACS.Controllers
{
    public class KetquaController : Controller
    {
        private testDACScontext db = new testDACScontext();

        // GET: Ketqua
        public ActionResult Index()
        {
            var du_thi = db.Du_thi.Include(d => d.HOCVIEN).Include(d => d.MONHOC);
            return View(du_thi.ToList());
        }

        public ActionResult KetquaSearch(int? searchString)
        {
            if (searchString == null)
                return Redirect("Index");
            var result = db.Du_thi.Include(d => d.HOCVIEN).Include(d => d.MONHOC).Where(p => p.MAHV == searchString).ToList();
            if (result.Count > 0)
                return View("Index", result);
            return HttpNotFound("Không có thông tin học viên!");
        }

        // GET: Ketqua/Details/5
        public ActionResult Details(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Du_thi du_thi = db.Du_thi.Find(id1,id2);
            if (du_thi == null)
            {
                return HttpNotFound();
            }
            return View(du_thi);
        }

        // GET: Ketqua/Create
        public ActionResult Create()
        {
            ViewBag.MAHV = new SelectList(db.HOCVIENs, "MAHV", "TENHV");
            ViewBag.MAMH = new SelectList(db.MONHOCs, "MAMH", "TENMH");
            return View();
        }

        // POST: Ketqua/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAHV,MAMH,KETQUA")] Du_thi du_thi)
        {
            if (ModelState.IsValid)
            {
                db.Du_thi.Add(du_thi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAHV = new SelectList(db.HOCVIENs, "MAHV", "TENHV", du_thi.MAHV);
            ViewBag.MAMH = new SelectList(db.MONHOCs, "MAMH", "TENMH", du_thi.MAMH);
            return View(du_thi);
        }

        // GET: Ketqua/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Du_thi du_thi = db.Du_thi.Find(id);
            if (du_thi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAHV = new SelectList(db.HOCVIENs, "MAHV", "TENHV", du_thi.MAHV);
            ViewBag.MAMH = new SelectList(db.MONHOCs, "MAMH", "TENMH", du_thi.MAMH);
            return View(du_thi);
        }

        // POST: Ketqua/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAHV,MAMH,KETQUA")] Du_thi du_thi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(du_thi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAHV = new SelectList(db.HOCVIENs, "MAHV", "TENHV", du_thi.MAHV);
            ViewBag.MAMH = new SelectList(db.MONHOCs, "MAMH", "TENMH", du_thi.MAMH);
            return View(du_thi);
        }

        // GET: Ketqua/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Du_thi du_thi = db.Du_thi.Find(id);
            if (du_thi == null)
            {
                return HttpNotFound();
            }
            return View(du_thi);
        }

        // POST: Ketqua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Du_thi du_thi = db.Du_thi.Find(id);
            db.Du_thi.Remove(du_thi);
            db.SaveChanges();
            return RedirectToAction("Index");
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
