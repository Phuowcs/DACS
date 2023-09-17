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
    public class TKBController : Controller
    {
        private testDACScontext db = new testDACScontext();

        // GET: TKB
        public ActionResult Index()
        {
            var lOPs = db.LOPs.Include(l => l.GIANGVIEN).Include(l => l.KHOAHOC).Include(l => l.THOIKHOABIEU);
            return View(lOPs.ToList());
        }

        public ActionResult TKB_1()
        {
            var tkb1 = db.LOPs.Include(l => l.GIANGVIEN).Include(l => l.KHOAHOC).Include(l => l.THOIKHOABIEU).Where(p => p.BIENLAIHOCPHIs.FirstOrDefault().MONHOC.MALV == 1).ToList();
            return View("Index", tkb1);
        }
        public ActionResult TKB_2()
        {
            var tkb1 = db.LOPs.Include(l => l.GIANGVIEN).Include(l => l.KHOAHOC).Include(l => l.THOIKHOABIEU).Where(p => p.BIENLAIHOCPHIs.FirstOrDefault().MONHOC.MALV == 2).ToList();
            return View("Index", tkb1);
        }
        public ActionResult TKB_3()
        {
            var tkb1 = db.LOPs.Include(l => l.GIANGVIEN).Include(l => l.KHOAHOC).Include(l => l.THOIKHOABIEU).Where(p => p.BIENLAIHOCPHIs.FirstOrDefault().MONHOC.MALV == 3).ToList();
            return View("Index", tkb1);
        }

        // GET: TKB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOP lOP = db.LOPs.Find(id);
            if (lOP == null)
            {
                return HttpNotFound();
            }
            return View(lOP);
        }

        // GET: TKB/Create
        public ActionResult Create()
        {
            ViewBag.MAGV = new SelectList(db.GIANGVIENs, "MAGV", "TENGV");
            ViewBag.MAKH = new SelectList(db.KHOAHOCs, "MAKH", "GHICHU");
            ViewBag.MATKB = new SelectList(db.THOIKHOABIEUx, "MATKB", "THU");
            return View();
        }

        // POST: TKB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALOP,TENLOP,MAGV,MAKH,MATKB")] LOP lOP)
        {
            if (ModelState.IsValid)
            {
                db.LOPs.Add(lOP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAGV = new SelectList(db.GIANGVIENs, "MAGV", "TENGV", lOP.MAGV);
            ViewBag.MAKH = new SelectList(db.KHOAHOCs, "MAKH", "GHICHU", lOP.MAKH);
            ViewBag.MATKB = new SelectList(db.THOIKHOABIEUx, "MATKB", "THU", lOP.MATKB);
            return View(lOP);
        }

        // GET: TKB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOP lOP = db.LOPs.Find(id);
            if (lOP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAGV = new SelectList(db.GIANGVIENs, "MAGV", "TENGV", lOP.MAGV);
            ViewBag.MAKH = new SelectList(db.KHOAHOCs, "MAKH", "GHICHU", lOP.MAKH);
            ViewBag.MATKB = new SelectList(db.THOIKHOABIEUx, "MATKB", "THU", lOP.MATKB);
            return View(lOP);
        }

        // POST: TKB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALOP,TENLOP,MAGV,MAKH,MATKB")] LOP lOP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAGV = new SelectList(db.GIANGVIENs, "MAGV", "TENGV", lOP.MAGV);
            ViewBag.MAKH = new SelectList(db.KHOAHOCs, "MAKH", "GHICHU", lOP.MAKH);
            ViewBag.MATKB = new SelectList(db.THOIKHOABIEUx, "MATKB", "THU", lOP.MATKB);
            return View(lOP);
        }

        // GET: TKB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOP lOP = db.LOPs.Find(id);
            if (lOP == null)
            {
                return HttpNotFound();
            }
            return View(lOP);
        }

        // POST: TKB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOP lOP = db.LOPs.Find(id);
            db.LOPs.Remove(lOP);
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
