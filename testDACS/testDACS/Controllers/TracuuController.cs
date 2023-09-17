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
    public class TracuuController : Controller
    {
        private testDACScontext db = new testDACScontext();

        // GET: Tracuu
        public ActionResult Index()
        {
            var bIENLAIHOCPHIs = db.BIENLAIHOCPHIs.Include(b => b.HOCVIEN).Include(b => b.LOP).Include(b => b.MONHOC).Where(p => p.MAHV == -1);
            return View(bIENLAIHOCPHIs.ToList());
        }


        public ActionResult TKBSearch(int? searchString)
        {
            if (searchString == null)
                return Redirect("Index");
            var result = db.BIENLAIHOCPHIs.Where(p => p.MAHV == searchString).ToList();
            if (result.Count > 0)
                return View("Index", result);
            return HttpNotFound("Không có thông tin học viên!");
        }

        // GET: Tracuu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIENLAIHOCPHI bIENLAIHOCPHI = db.BIENLAIHOCPHIs.Find(id);
            if (bIENLAIHOCPHI == null)
            {
                return HttpNotFound();
            }
            return View(bIENLAIHOCPHI);
        }

        // GET: Tracuu/Create
        public ActionResult Create()
        {
            ViewBag.MAHV = new SelectList(db.HOCVIENs, "MAHV", "TENHV");
            ViewBag.MALOP = new SelectList(db.LOPs, "MALOP", "TENLOP");
            ViewBag.MAMH = new SelectList(db.MONHOCs, "MAMH", "TENMH");
            return View();
        }

        // POST: Tracuu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MABL,HOCPHI,MAHV,MAMH,MALOP")] BIENLAIHOCPHI bIENLAIHOCPHI)
        {
            if (ModelState.IsValid)
            {
                db.BIENLAIHOCPHIs.Add(bIENLAIHOCPHI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAHV = new SelectList(db.HOCVIENs, "MAHV", "TENHV", bIENLAIHOCPHI.MAHV);
            ViewBag.MALOP = new SelectList(db.LOPs, "MALOP", "TENLOP", bIENLAIHOCPHI.MALOP);
            ViewBag.MAMH = new SelectList(db.MONHOCs, "MAMH", "TENMH", bIENLAIHOCPHI.MAMH);
            return View(bIENLAIHOCPHI);
        }

        // GET: Tracuu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIENLAIHOCPHI bIENLAIHOCPHI = db.BIENLAIHOCPHIs.Find(id);
            if (bIENLAIHOCPHI == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAHV = new SelectList(db.HOCVIENs, "MAHV", "TENHV", bIENLAIHOCPHI.MAHV);
            ViewBag.MALOP = new SelectList(db.LOPs, "MALOP", "TENLOP", bIENLAIHOCPHI.MALOP);
            ViewBag.MAMH = new SelectList(db.MONHOCs, "MAMH", "TENMH", bIENLAIHOCPHI.MAMH);
            return View(bIENLAIHOCPHI);
        }

        // POST: Tracuu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MABL,HOCPHI,MAHV,MAMH,MALOP")] BIENLAIHOCPHI bIENLAIHOCPHI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bIENLAIHOCPHI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAHV = new SelectList(db.HOCVIENs, "MAHV", "TENHV", bIENLAIHOCPHI.MAHV);
            ViewBag.MALOP = new SelectList(db.LOPs, "MALOP", "TENLOP", bIENLAIHOCPHI.MALOP);
            ViewBag.MAMH = new SelectList(db.MONHOCs, "MAMH", "TENMH", bIENLAIHOCPHI.MAMH);
            return View(bIENLAIHOCPHI);
        }

        // GET: Tracuu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIENLAIHOCPHI bIENLAIHOCPHI = db.BIENLAIHOCPHIs.Find(id);
            if (bIENLAIHOCPHI == null)
            {
                return HttpNotFound();
            }
            return View(bIENLAIHOCPHI);
        }

        // POST: Tracuu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BIENLAIHOCPHI bIENLAIHOCPHI = db.BIENLAIHOCPHIs.Find(id);
            db.BIENLAIHOCPHIs.Remove(bIENLAIHOCPHI);
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
